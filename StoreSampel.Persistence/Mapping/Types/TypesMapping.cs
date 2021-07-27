using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreSampel.Domain.Entities.Types;

namespace StoreSampel.Persistence.Mapping.Types
{
    public class TypesMapping:IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder.ToTable("Types");
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Model)
                .WithMany(c => c.Types)
                .HasForeignKey(c => c.ModelId);
        }
    }
}