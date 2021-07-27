using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreSampel.Domain.Entities.Brands;
using StoreSampel.Domain.Entities.Models;
using StoreSampel.Domain.Entities.Orders;
using StoreSampel.Domain.Entities.Products;
using StoreSampel.Domain.Entities.Types;
using StoreSampel.Domain.Identity;
using StoreSampel.Persistence.Mapping.Brands;
using StoreSampel.Persistence.Mapping.Models;
using StoreSampel.Persistence.Mapping.Orders;
using StoreSampel.Persistence.Mapping.Products;
using StoreSampel.Persistence.Mapping.Types;


namespace StoreSampel.Persistence.Context
{
    public class StoreSampelContext:IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public StoreSampelContext(DbContextOptions<StoreSampelContext> Options)
        :base(Options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new BrandMapping());
            modelBuilder.ApplyConfiguration( new ModelsMapping());
            modelBuilder.ApplyConfiguration( new TypesMapping());
            modelBuilder.ApplyConfiguration( new ProductMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
          

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Type> Types { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        #endregion
    }
}