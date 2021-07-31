using System;
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

            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "111",
                BrandId = 3,
                Id = 1
            });
            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "131",
                BrandId = 3,
                Id = 2
            });
            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "141",
                BrandId = 3,
                Id = 3
            });
            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "405GLX",
                BrandId = 1,
                Id = 4
            });
            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "405slx",
                BrandId = 1,
                Id = 5
            });
          
            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "مگان",
                BrandId = 2,
                Id = 6
            });
            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "سانرو",
                BrandId = 2,
                Id = 7
            });
            builder.HasData(new Model()
            {
                CreateDate = DateTime.Now,
                Name = "کولیوس",
                BrandId = 2,
                Id = 8
            });
        }
    }
}