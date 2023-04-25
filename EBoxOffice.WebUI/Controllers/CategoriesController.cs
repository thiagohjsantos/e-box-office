using EBoxOffice.Application.DTOs;
using EBoxOffice.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EBoxOffice.WebUI.Controllers
{
    [Authorize(Roles ="Company")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryVM = await _categoryService.GetById(id);

            if (categoryVM == null) return NotFound();

            return View(categoryVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryVM = await _categoryService.GetById(id);

            if (categoryVM == null) return NotFound();

            return View(categoryVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoryVM = await _categoryService.GetById(id);

            if (categoryVM == null) return NotFound();

            return View(categoryVM);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(category);
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
