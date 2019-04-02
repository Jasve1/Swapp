using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swapp.Data;
using Swapp.Models;
using Microsoft.AspNetCore.Identity;

namespace Swapp.Components
{
    public class TopNavigationViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private AppIdentityDbContext dataContext;

        public TopNavigationViewComponent(UserManager<AppUser> userMgr, AppIdentityDbContext dbContext)
        {
            userManager = userMgr;
            dataContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            //I want to be able to show all the information that is stored in the database of the current user
            var userId = userManager.GetUserId(HttpContext.User);

            AppUser currentUser = dataContext.Users.Where(u => u.Id == userId).First();

            ViewBag.UserId = userId;
            ViewBag.ProfilePicture = currentUser.ProfilePic;

            return View();
        }
    }
}
