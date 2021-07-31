using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Orders;
using StoreSampel.UI.Areas.Admin.ViewModel;
using StorSampel.Common;

namespace StoreSampel.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "User,Admin")]
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _uw;

        public OrdersController(IUnitOfWork uw)
        {
            _uw = uw;
        }
        public async Task<IActionResult> Index()
        {
            var orderViewModel=new List<OrderViewModel>();
            var orders =await _uw.OrderRepository.GetAllOrders();
            foreach (var item in orders)
            {
                orderViewModel.Add(new OrderViewModel()
                {
                    ModelName = item.Model.Name,
                    Status = (StringExtensions.Status) item.Status,
                    TypeName = item.Type.Name,
                    FullName = item.User.FullName,
                    BrandName = item.Brand.Name,
                    OrderId = item.Id,
                    UserName = item.User.UserName
                });
            }
            return View(orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Confirm(string orderId,int status)
        {
            if (!string.IsNullOrWhiteSpace(orderId) && !string.IsNullOrWhiteSpace(status.ToString()))
            {
                var findOrder = await _uw.OrderRepository.GetOrderById(orderId);
                findOrder.Status = (Status)status;
               await _uw.OrderRepository.UpdateOrder(findOrder);
               await _uw.Commit();
               return Redirect("/admin/orders/index");
            }
            return Redirect("/admin/orders/index");
        }
      
    }
}