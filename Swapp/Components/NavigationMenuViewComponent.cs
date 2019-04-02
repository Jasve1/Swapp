using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swapp.Models;
using Swapp.Data;

namespace Swapp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private AppIdentityDbContext dataContext;

        public NavigationMenuViewComponent(AppIdentityDbContext dbContext)
        {
            dataContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(dataContext.Category
            .Select(x => x.CategoryName)
            .Distinct()
            .OrderBy(x => x));
        }

    }
}
