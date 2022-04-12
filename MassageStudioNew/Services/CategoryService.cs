using MassageStudioApp.Abstractions;
using MassageStudioApp.Data;
using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, string description, decimal price)
        {
            Category item = new Category
            {
                Name = name,
                Description = description,
                Price = price
            };

            _context.Categories.Add(item);
            return _context.SaveChanges() != 0;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int Id)
        {
            var item = _context.Categories.Find(Id);
            if (item == null)
            {
                return false;
            }
            _context.Categories.Remove(item);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateCategory(string Name, string Description, decimal Price)
        {
            throw new NotImplementedException();
        }
    }
}
