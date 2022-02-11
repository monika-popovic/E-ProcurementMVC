using E_Procurement.Data.Repository;
using E_Procurement.Helpers;
using E_Procurement.Models;
using E_Procurement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace E_Procurement.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryRepository _repository;

        public SubcategoryController(ISubcategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int? pageNumber, string searchString, string searchString2)
        {
            //var subcategories = _repository.GetSubcategories();
            //return Ok(subcategories);

            ViewData["CurrentFilter"] = searchString;

            var subcategories = _repository.GetSubcategoriesAsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                subcategories = subcategories.Where(x => x.CPVCode == searchString);
            }

            if (!string.IsNullOrEmpty(searchString2))
            {
                subcategories = subcategories.Where(x => x.Category.Name == searchString2);
            }

            int pageSize = 3;
            return View(await PaginatedListHelper<Subcategory>.CreateAsync(
                subcategories.AsNoTracking(),
                pageNumber ?? 1,
                pageSize
                ));
            // return View(subcategories);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Categories = new SelectList(_repository.GetCategories(), "Id", "Name");

            //If id == null then create new post, else update the post
            if (id == null)
                return View(new SubcategoryViewModel());
            else
            {
                var subcategory = _repository.GetSubcategoryById((int)id);

                ViewBag.Categories = new SelectList(_repository.GetCategories(), "Id", "Name", subcategory.CategoryId);

                return View("Edit", new SubcategoryViewModel
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    CPVCode = subcategory.CPVCode,
                    CategoryId = subcategory.CategoryId,
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubcategoryViewModel subcategoryVM)
        {
            var subcategory = new Subcategory
            {
                Id = subcategoryVM.Id,
                Name = subcategoryVM.Name,
                CPVCode = subcategoryVM.CPVCode,
                CategoryId = subcategoryVM.CategoryId,
            };

            if (subcategory.Id == null)
                _repository.AddSubcategory(subcategory);
            else
                _repository.UpdateSubcategory(subcategory);

            if (await _repository.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_repository.GetCategories(), "Id", "Name");
            return View(subcategoryVM);

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            _repository.DeleteSubcategory(id);
            await _repository.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
