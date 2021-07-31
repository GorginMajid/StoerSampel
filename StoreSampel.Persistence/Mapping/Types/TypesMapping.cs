using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = StoreSampel.Domain.Entities.Types.Type;

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

            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی",
                ModelId =5,
                Id = 1
            });

            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی",
                ModelId = 4,
                Id = 2
            });
            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "دوگانه سوز",
                ModelId = 4,
                Id = 3
            });
            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی",
                ModelId = 1,
                Id = 4
            });
            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی slx",
                ModelId = 1,
                Id = 5
            });
            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی 1700cc",
                ModelId = 6,
                Id = 6
            });
            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی 2000cc",
                ModelId = 6,
                Id = 7
            });
            builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی 1800cc",
                ModelId = 7,
                Id = 8
            });
             builder.HasData(new Type()
            {

                CreateDate = DateTime.Now,
                Name = "بنزینی cross over",
                ModelId = 7,
                Id = 9
             });
             builder.HasData(new Type()
             {

                 CreateDate = DateTime.Now,
                 Name = "بنزینی ",
                 ModelId =8,
                 Id = 10
             });
        }
    }
}