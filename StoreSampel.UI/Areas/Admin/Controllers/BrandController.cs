using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Brands;
using StoreSampel.UI.Areas.Admin.ViewModel;

namespace StoreSampel.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _uw;
        private const string redirectToBrand = "/admin/brand/";

        public BrandController(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IActionResult> Index()
        {
            var ViewModel = new List<BrandViewModel>();

            var result = await _uw.BrandRepository.GetAllBrands();
            foreach (var item in result)
            {
                ViewModel.Add(new BrandViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long Id)
        {
            if (Id == 0)
                return NotFound();
            await _uw.BrandRepository.DeleteBrand(Id);
            await _uw.Commit();
            return Redirect(redirectToBrand);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _uw.BrandRepository.InsertBrand(new Brand() {Name = model.Name});
                await _uw.Commit();
                return Redirect("/admin/brand/index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long Id)
        {
            if (Id == 0) return NotFound();

            var result = await _uw.BrandRepository.GetBrandById(Id);
            return View(new BrandViewModel() {Id = result.Id, Name = result.Name});
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brnad= new Brand(){

                    Id = model.Id,
                    Name = model.Name,
                    
                };
                await _uw.BrandRepository.UpdateBrand(brnad);
               await _uw.Commit();
               return Redirect(redirectToBrand);
            }

            return View(model);
        }
    }
}