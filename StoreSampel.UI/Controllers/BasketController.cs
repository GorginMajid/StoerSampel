using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Identity;
using StorSampel.Common;

namespace StoreSampel.UI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUnitOfWork _uw;
        private readonly UserManager<ApplicationUser> _userManager;

        public BasketController(IUnitOfWork uw, UserManager<ApplicationUser> userManager)
        {
            _uw = uw;
            _userManager = userManager;
        }

     
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = await _uw.BasketRepository.GetBaskets(User.Identity.GetUserId<int>());
            ViewData["FullName"] =user.FullName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GetProducts(string id)
        {
            var result = await _uw.BasketRepository.Products(id);
         
            return Json(JsonConvert.SerializeObject(result));
        }
    }
}