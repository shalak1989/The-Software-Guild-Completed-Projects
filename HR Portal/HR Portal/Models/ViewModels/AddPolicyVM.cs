using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;
using HR_Portal.Models.Repositories;
using System.Web.Mvc;

namespace HR_Portal.Models.ViewModels
{
    public class AddPolicyVM
    {
        public Policy Policy { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }


        public AddPolicyVM()
        {
            CategoryItems = new List<SelectListItem>();
        }

        public void SetCategoryItems(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                CategoryItems.Add(new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.CategoryName
                });

            }
        }

    }
}