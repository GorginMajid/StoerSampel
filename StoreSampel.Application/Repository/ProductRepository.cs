using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Products;

namespace StoreSampel.Application.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly IUnitOfWork _uw;

        public ProductRepository(IUnitOfWork uw)
        {
            _uw = uw;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var result = await _uw.BaseRepository<Product>().FindAllAsync();
            return result.ToList();
        }

        public async Task<Product> GetProductById(long productId)
        {
            var result = await _uw.BaseRepository<Product>().FindByIdAsync(productId);
            return result;
        }

        public async Task InsertProduct(Product product)
        {
            await _uw.BaseRepository<Product>().CreateAsync(product);
        }

        public async Task InsertRangeProduct(List<Product> product)
        {
            await _uw.BaseRepository<Product>().CreateRangeAsync(product);
        }

        public async Task DeleteProduct(Product product)
        {
            _uw.BaseRepository<Product>().Delete(product);  await Task.CompletedTask;
        }

        public async Task DeleteProduct(long productId)
        {
            var delete = await GetProductById(productId);
            await DeleteProduct(delete);
        }

        public async Task UpdateProduct(Product product)
        {
            _uw.BaseRepository<Product>().Update(product);  await Task.CompletedTask;
        }
    }
}