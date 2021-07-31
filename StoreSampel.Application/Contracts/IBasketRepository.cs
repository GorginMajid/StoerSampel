using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSampel.Application.BasketsDTO;

namespace StoreSampel.Application.Contracts
{
    public interface IBasketRepository
    {
        Task<IEnumerable<BasketDTO>> GetBaskets(int userId);
        Task<List<ProductOrder>> Products(string orderId);
    }
}