using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;
using System.Web.Mvc;

namespace HR_Portal.Models.ViewModels
{
    public class PolicyVM
    {
        public Policy Policy { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }

        public PolicyVM()
        {
            CategoryItems = new List<SelectListItem>();
            Policy = new Policy();
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