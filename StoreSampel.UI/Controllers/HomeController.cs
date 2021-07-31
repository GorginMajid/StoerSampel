using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Brands;
using StoreSampel.UI.Models;

namespace StoreSampel.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _uw;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork uw)
        {
            _logger = logger;
            _uw = uw;
        }


        public  IActionResult Index()
        {

           
            return View();
        }

        public async Task<JsonResult> GetModel(int Id)
        {
            var models = await _uw.ModelRepository.GetModelByBrnadId(Id);
            return Json(JsonConvert.SerializeObject(models));
        }
    }
}
