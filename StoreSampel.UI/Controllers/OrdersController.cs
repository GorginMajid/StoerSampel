using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Orders;
using StoreSampel.Domain.Entities.Products;
using StoreSampel.Domain.Identity;
using StoreSampel.UI.Models.OrdersViewModel;
using StorSampel.Common;
using System.Threading.Tasks;
using StoreSampel.UI.Models.ProductsViewModel;

namespace StoreSampel.UI.Controllers
{
    [Authorize(Roles = "User,admin")]

    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _Uw;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public OrdersController(IUnitOfWork uw, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _Uw = uw;
        }
        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {

            ViewBag.Brand = new SelectList(await _Uw.BrandRepository.GetAllBrands(), "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Id = StringExtensions.GenerateId(4),
                    BrandId = model.BrnadId,
                    ModelId = model.ModelId,
                    TypeId = model.TypeId,
                    CreateDate = DateTime.Now,
                    UserId = User.Identity.GetUserId<int>(),
                    Status = Status.Pending,

                };
                var product = new List<Product>();

                for (int i = 0; i <= model.ProductType.Length - 1;)
                {
                    product.Add(new Product()
                    {
                        ProductType = model.ProductType[i],
                        CreateDate = DateTime.Now,
                        OrderId = order.Id,
                        ProductValue = model.ProductValues[i]
                    });
                    i++;
                }
                await _Uw.OrderRepository.InsertOrder(order);
                await _Uw.ProductRepository.InsertRangeProduct(product);
                await _Uw.Commit();

                return Redirect("/");
            }
            ViewBag.Brand = new SelectList(await _Uw.BrandRepository.GetAllBrands(), "Id", "Name");

            return View(model);
        }
       
        [HttpGet]
        public async Task<IActionResult> GetModel(int Id)
        {
            var models = await _Uw.ModelRepository.GetModelByBrnadId(Id);
            return Json(JsonConvert.SerializeObject(models));
        }
        [HttpGet]
        public async Task<IActionResult> GetBrands(int Id)
        {
            var models = await _Uw.TypeRepository.GetTypeByModelId(Id);
            return Json(JsonConvert.SerializeObject(models));

        }

     
    }
}