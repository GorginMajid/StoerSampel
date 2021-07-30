using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSampel.Domain.Entities.Brands;
using StoreSampel.Domain.Entities.Orders;

namespace StoreSampel.Application.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(string orderId);
        Task InsertOrder(Order order);
        Task DeleteOrder(Order order);
        Task DeleteOrder(string orderId);
        Task UpdateOrder(Order order);
    }
}