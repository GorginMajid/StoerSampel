using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreSampel.Application.Contracts;
using StoreSampel.Domain.Entities.Models;
using StoreSampel.UI.Areas.Admin.ViewModel;

namespace StoreSampel.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        private const string redirectToModel = "/admin/model/";
        private IUnitOfWork _uw;

        public ModelController(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IActionResult> Index()
        {

            var ViewModel = new List<ModelViewModel>();

            var result = await _uw.ModelRepository.GetAllModels();
            foreach (var item in result)
            {
                ViewModel.Add(new ModelViewModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return View(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
                return NotFound();
            await _uw.ModelRepository.DeleteModel(Id);
            await _uw.Commit();
            return Redirect(redirectToModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Brand = new SelectList(await _uw.BrandRepository.GetAllBrands(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _uw.ModelRepository.InsertModel(new Model()
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                });
                await _uw.Commit();
                return Redirect(redirectToModel);
            }

            ViewBag.Brand = new SelectList(await _uw.BrandRepository.GetAllBrands(), "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == 0) return NotFound();

            var model = await _uw.ModelRepository.GetModelById(Id);
            ViewBag.Brand = new SelectList(await _uw.BrandRepository.GetAllBrands(), "Id", "Name");
            var viewModel = new ModelViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                BrandId = model.BrandId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _uw.ModelRepository.UpdateModel(new Model()
                {
                    Id = model.Id,
                    BrandId = model.BrandId,
                    Name = model.Name
                });
              await  _uw.Commit();
              return Redirect(redirectToModel);
            }
            ViewBag.Brand = new SelectList(await _uw.BrandRepository.GetAllBrands(), "Id", "Name");
            return View(model);
        }
    }
}