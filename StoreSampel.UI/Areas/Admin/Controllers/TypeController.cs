using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreSampel.Application.Contracts;
using StoreSampel.UI.Areas.Admin.ViewModel;
using Type = StoreSampel.Domain.Entities.Types.Type;

namespace StoreSampel.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TypeController : Controller
    {
        private const string redirectTotype = "/admin/type/";
        private IUnitOfWork _uw;

        public TypeController(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IActionResult> Index()
        {
            var ViewModel = new List<TypeViewModel>();

            var result = await _uw.TypeRepository.GetAllTypes();
            foreach (var item in result)
            {
                ViewModel.Add(new TypeViewModel()
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
            await _uw.TypeRepository.DeleteType(Id);
            await _uw.Commit();
            return Redirect(redirectTotype);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Model = new SelectList(await _uw.ModelRepository.GetAllModels(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _uw.TypeRepository.InsertType(new Type()
                {
                    Name = model.Name,
                    ModelId = model.ModelId
                });
                await _uw.Commit();
                return Redirect(redirectTotype);
            }

            ViewBag.Model = new SelectList(await _uw.ModelRepository.GetAllModels(), "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == 0) return NotFound();

            var type = await _uw.TypeRepository.GetTypeById(Id);
            ViewBag.Model = new SelectList(await _uw.ModelRepository.GetAllModels(), "Id", "Name");
            var viewModel = new TypeViewModel()
            {
                Id = type.Id,
                Name = type.Name,
                ModelId = type.ModelId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _uw.TypeRepository.UpdateType(new Type()
                {
                    Id = model.Id,
                    ModelId = model.ModelId,
                    Name = model.Name
                });
                await _uw.Commit();
                return Redirect(redirectTotype);
            }
            ViewBag.Brand = new SelectList(await _uw.BrandRepository.GetAllBrands(), "Id", "Name");
            return View(model);
        }
    }
}