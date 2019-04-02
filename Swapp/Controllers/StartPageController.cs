using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swapp.Models;
using Swapp.Models.ViewModels;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Swapp.Data;

namespace Swapp.Controllers
{
    [Authorize]
    public class StartPageController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private IHostingEnvironment hostingEnvironment;
        private AppIdentityDbContext dataContext;

        public StartPageController(UserManager<AppUser> usrMgr, SignInManager<AppUser> signinMgr, 
            IHostingEnvironment environment, AppIdentityDbContext context)
        {
            userManager = usrMgr;
            signInManager = signinMgr;
            hostingEnvironment = environment;
            dataContext = context;
        }

        [AllowAnonymous]
        public IActionResult Index(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public IActionResult SignUp(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUp model, string returnUrl)
        {
            if (ModelState.IsValid)
            { 
                //Extract Image File Name.
                string fileName = Path.GetFileName(model.ProfilePic.FileName);

                //Set the Image File Path.
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "images/profilePics");
                var filePath = Path.Combine(uploads, fileName);

                //Save a path the database
                string dbPath = fileName;

                //Save the Image File in Folder.
                model.ProfilePic.CopyTo(new FileStream(filePath, FileMode.Create));

                //take image from form and upload image to server and then send path to database
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    LastName = model.LastName,
                    Email = model.Email,
                    City = model.City,
                    ProfilePic = dbPath 
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult signinResult = await signInManager.PasswordSignInAsync(
                    user, model.Password, false, false);
                if (signinResult.Succeeded)
                {
                    return Redirect(returnUrl ?? "/swapp");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public JsonResult ValidateEmail(string Email)
        {

            List<AppUser> queryResult = dataContext.Users.Where(u => u.Email == Email).ToList();

            if (queryResult.ToList().Count > 0)
            {
                return Json("The Email is already in use");
            }
            else
            {
                return Json(true);
            }

        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(
                        user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/swapp");
                    }
                }
                ModelState.AddModelError(nameof(details.Email), "Invalid user or password");
            }
            return View(details);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}