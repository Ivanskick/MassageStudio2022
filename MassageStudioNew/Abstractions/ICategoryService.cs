using MassageStudioApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Abstractions
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();
        
        Category GetCategoryById(int id);

        bool Create(string Name, string Description, decimal Price);
        
        bool UpdateCategory(string Name, string Description, decimal Price);
        bool RemoveById(int Id);
    }
}
