using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Orders;

namespace StoreSampel.Application.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly IUnitOfWork _uw;

        public OrderRepository(IUnitOfWork uw)
        {
            _uw = uw;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var result = await _uw._Context.Orders.Include(b=>b.Brand).Include(m=>m.Model)
                .Include(y=>y.Type)
                .Include(c=>c.User).ToListAsync();
            return result.ToList();
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            var result = await _uw.BaseRepository<Order>().FindByIdAsync(orderId);
            return result;
        }

        public async Task InsertOrder(Order order)
        {
            await _uw.BaseRepository<Order>().CreateAsync(order);
        }

        public async Task DeleteOrder(Order order)
        {
            _uw.BaseRepository<Order>().Delete(order);  await Task.CompletedTask;
        }

        public async Task DeleteOrder(string orderId)
        {
            var delete = await GetOrderById(orderId);
            await DeleteOrder(delete);
        }

        public async Task UpdateOrder(Order order)
        {
            _uw.BaseRepository<Order>().Update(order);  await Task.CompletedTask;
        }
    }
}