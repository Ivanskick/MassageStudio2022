using MassageStudioApp.Abstractions;
using MassageStudioApp.Entities;
using MassageStudioApp.Models.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoriesController1
        public ActionResult Index()
        {
            var users = _categoryService.GetCategories()
                   .Select(u => new CategoryListingVM
                   {
                        Id = u.Id,
                        Name = u.Name,
                        Description = u.Description,
                        Price = u.Price
                    }).ToList();

                    return this.View(users);
                    }

        // GET: CategoriesController1/Details/5
        public ActionResult Details(int id)
        {
            Category item = _categoryService.GetCategoryById(id);
            if (item == null)
            {
                return NotFound();
            }
            CategoryDetailsVM category = new CategoryDetailsVM()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };
            return View(category);
        }

        // GET: CategoriesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryVM category)
        {
            if (ModelState.IsValid)
            {
                var created = _categoryService.Create(category.Name, category.Description, category.Price);
                if (created)
                {
                    return this.RedirectToAction("Index");
                }
            }

            return this.View();
        }

        // GET: CategoriesController1/Edit/5
        public IActionResult Edit(int id)
        {
            Category item = _categoryService.GetCategoryById(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateCategoryVM category = new CreateCategoryVM()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };
            return View(category);
        }

        // POST: CategoriesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateCategoryVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _categoryService.UpdateCategory(bindingModel.Name, bindingModel.Description, bindingModel.Price);
                if (updated)
                {
                    return this.RedirectToAction("All");
                }

            }
            return View(bindingModel);
        }

        // GET: CategoriesController1/Delete/5
        public ActionResult Delete(int id)
        {
            Category item = _categoryService.GetCategoryById(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateCategoryVM category = new CreateCategoryVM()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };
            return View(category);
        }

        // POST: CategoriesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _categoryService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("All", "Categories");
            }
            else
            {
                return View();
            }

        }
    }
}
