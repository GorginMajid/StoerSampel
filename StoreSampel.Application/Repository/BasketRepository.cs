using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreSampel.Application.BasketsDTO;
using StoreSampel.Application.Contracts;
using StorSampel.Common;

namespace StoreSampel.Application.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IUnitOfWork _uw;

        public BasketRepository(IUnitOfWork uw)
        {
            _uw = uw;
        }
        public async Task<IEnumerable<BasketDTO>> GetBaskets(int userId)
        {
            var BasketViewModel = new List<BasketDTO>();
          
           
            var BasketUser = await _uw._Context.Orders.Where(c => c.UserId == userId)
                .Include(c => c.Brand).Include(c => c.Model)
                .Include(c => c.Type)
                .ToListAsync();




            foreach (var item in BasketUser)
            {
                //var ProductsOrder = await _uw._Context.Products.Where(c => c.OrderId == item.Id).ToListAsync();
                //foreach (var product in ProductsOrder)
                //{
                //    productsOrder.Add(new ProductOrder()
                //    {
                //        ProductType = product.ProductType,
                //        ProductValue = (int)product.ProductValue
                //    });
                //}
                BasketViewModel.Add(new BasketDTO()
                {
                    BrnadName = item.Brand.Name,
                    ModelName = item.Model.Name,
                    OrderId = item.Id,
                    RegisterDate = item.CreateDate.ConvertMiladiToShamsi("yyyy MMMM d"),
                    Status = (StringExtensions.Status)item.Status,
                    TypeName = item.Type.Name,
                
                });
             
            }

            
           
            return BasketViewModel;
        }

        public async Task<List<ProductOrder>> Products(string orderId)
        {
            var products =  _uw._Context.Products.Where(p => p.OrderId == orderId).Select(c => new ProductOrder()
            {
                ProductType = c.ProductType,
                ProductValue = c.ProductValue,
                OrderId = c.OrderId
            });

            return await products.ToListAsync();
        }
    }
}