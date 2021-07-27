using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StoreSampel.Application.Contracts;
using StoreSampel.UI.Models;
using StoreSampel.UI.Models.OrdersViewModel;

namespace StoreSampel.UI.Controllers
{
    [Authorize(Roles = "User")]
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _Uw;

        public OrdersController( IUnitOfWork uw)
        {
           
            _Uw = uw;
        }

        public async Task<IActionResult> Index()
        {
         
            ViewBag.Brand = new SelectList(await _Uw.BrandRepository.GetAllBrands(), "Id", "Name");
          
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

        [HttpPost]
        public  IActionResult CheckOut(OrderViewModel model)
        {
            return Redirect("/");
        }
    }
}