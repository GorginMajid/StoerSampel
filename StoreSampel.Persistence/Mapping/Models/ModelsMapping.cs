using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreSampel.Domain.Entities.Models;

namespace StoreSampel.Persistence.Mapping.Models
{
    public class ModelsMapping:IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Models");
            builder.HasKey(c => c.Id);


            builder.HasOne(c => c.Brand)
                .WithMany(c => c.Models)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}