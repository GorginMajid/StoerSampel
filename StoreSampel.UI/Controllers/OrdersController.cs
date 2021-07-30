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
    [Authorize(Roles = "User,Admin")]

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

            var products = new List<Product>();
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

               await _Uw.OrderRepository.InsertOrder(order);
               await _Uw.Commit();

                return Redirect("/");
            }
            ViewBag.Brand = new SelectList(await _Uw.BrandRepository.GetAllBrands(), "Id", "Name");

            return View(model);
        }

        public IActionResult AddProducts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProducts(م)
        {
            iفسهf (ModelState.IsValid)
            {
                var Model = model;
         return View();
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