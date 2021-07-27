using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreSampel.Domain.Entities.Orders;

namespace StoreSampel.Persistence.Mapping.Orders
{
    public class OrderMapping:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(c => c.Id);


            builder.HasOne(c => c.Brand)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.BrandId).OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(c => c.Model)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Type)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.TypeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}