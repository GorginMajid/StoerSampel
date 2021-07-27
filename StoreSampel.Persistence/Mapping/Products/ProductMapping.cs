using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreSampel.Domain.Entities.Products;

namespace StoreSampel.Persistence.Mapping.Products
{
    public class ProductMapping:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.User)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.UserId);
        }
    }
}