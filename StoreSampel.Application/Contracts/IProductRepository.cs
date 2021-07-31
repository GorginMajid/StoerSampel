using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSampel.Domain.Entities.Products;

namespace StoreSampel.Application.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(long productId);
        Task InsertProduct(Product product);
        Task InsertRangeProduct(List<Product> product);
        Task DeleteProduct(Product product);
        Task DeleteProduct(long productId);
        Task UpdateProduct(Product product);
    }
}