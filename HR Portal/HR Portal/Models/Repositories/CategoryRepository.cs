using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;

namespace HR_Portal.Models.Repositories
{
    public static class CategoryRepository
    {
        private static List<Category> _categories;

        static CategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category {CategoryId = 1, CategoryName = "Dress Code" },
                new Category {CategoryId = 2, CategoryName = "Attendance" },
                new Category {CategoryId = 3, CategoryName = "Workplace Conduct" }
            };
        }

        public static IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public static Category Get(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public static void Add(Category category)
        {
            _categories.Add(category);
        }

        public static void Delete(int categoryId)
        {
            _categories.RemoveAll(c => c.CategoryId == categoryId);
        }
    }
}