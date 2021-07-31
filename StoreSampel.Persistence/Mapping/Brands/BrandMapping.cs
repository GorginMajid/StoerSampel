using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreSampel.Domain.Entities.Brands;

namespace StoreSampel.Persistence.Mapping.Brands
{
    public class BrandMapping:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Brands");
            builder.HasData(
                new Brand()
                {
                    CreateDate = DateTime.Now,
                    Name = "خانواده پژو",
                    Id = 1
                });
            builder.HasData(
                new Brand()
                {
                    CreateDate = DateTime.Now,
                    Name = "خانواده رنو",
                    Id = 2
                });
            builder.HasData(
                new Brand()
                {
                    CreateDate = DateTime.Now,
                    Name = "خانواده پراید",
                    Id = 3
                });
        }
    }
}