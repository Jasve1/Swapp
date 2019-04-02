using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swapp.Models;
using Swapp.Models.ViewModels;
using Swapp.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Swapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private AppIdentityDbContext dataContext;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
        private SignInManager<AppUser> signInManager;
        private IHostingEnvironment hostingEnvironment;

        public HomeController(UserManager<AppUser> userMgr, AppIdentityDbContext idDbContext,
            IUserValidator<AppUser> userValid,
            IPasswordValidator<AppUser> passwordValid, IPasswordHasher<AppUser> passwordHash, 
            SignInManager<AppUser> signinMgr, IHostingEnvironment environment)
        {
            userManager = userMgr;
            dataContext = idDbContext;
            userValidator = userValid;
            passwordValidator = passwordValid;
            passwordHasher = passwordHash;
            signInManager = signinMgr;
            hostingEnvironment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {
            //I want to be able to show all the information that is stored in the database of the current user
            var userId = userManager.GetUserId(HttpContext.User);

            AppUser currentUser = dataContext.Users.Where(u => u.Id == userId).First();
            AppUser user = new AppUser
            {
                UserName = currentUser.UserName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                City = currentUser.City,
                ProfilePic = currentUser.ProfilePic
            };

            List<Product> products = new List<Product>();

            List<Product> productsOfCurrentUser = dataContext.Product.Where(p => p.AspNetUserId == userId)
                .Include(p => p.Category).Include(p => p.Images).ToList();

            foreach(Product p in productsOfCurrentUser)
            {
                Product product = new Product()
                {
                    ProductId = p.ProductId,
                    ProductDescription = p.ProductDescription,
                    ProductName = p.ProductName,
                    CategoryId = p.CategoryId,
                    AspNetUserId = p.AspNetUserId,
                    AspNetUser = user,
                    Category = p.Category,
                    Images = p.Images
                };
                products.Add(product);
            }
            

            UserViewModel userDisplay = new UserViewModel
            {
                AppUser = user,
                Products = products,
            };

            ViewBag.UserId = userId;
            ViewBag.ProfilePicture = currentUser.ProfilePic;

            return View(userDisplay);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, string profilePic)
        {
            string serverPath = hostingEnvironment.WebRootPath;

            List<Product> products = dataContext.Product.Where(p => p.AspNetUserId == id)
                .Include(p => p.Images).ToList();

            foreach (var p in products)
            {
                List<Image> images = p.Images.ToList();

                foreach (var i in images)
                {
                    string imgPath = Path.Combine(serverPath, "images/profilePics/" + i.ImageUrl);
                    System.IO.File.Delete(imgPath);
                    dataContext.Remove(i);
                }

                dataContext.SaveChanges();

                dataContext.Remove(p);
            }
            
            dataContext.SaveChanges();

            //First I need to delete the old picture
            string oldPath = Path.Combine(serverPath, "images/profilePics/" + profilePic);

            System.IO.File.Delete(oldPath);

            dataContext.Remove(dataContext.Users.Where(a => a.Id == id).First());
            await dataContext.SaveChangesAsync();

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser NewDetails, IFormFile pictureFile, string profilePic)
        {
            

            if (ModelState.IsValid)
            {

                //Find the current user. Then get the id of that user.  
                //Then send tell the entity framwork to update the user with that id with the new data given by the parameters
                AppUser user = await userManager.FindByIdAsync(NewDetails.Id);

                user.Email = NewDetails.Email;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                user.City = NewDetails.City;
                user.UserName = NewDetails.UserName;
                user.LastName = NewDetails.LastName;

                if (pictureFile == null || pictureFile.Length == 0)
                {
                    user.ProfilePic = profilePic;
                }
                else
                {
                    //First I need to delete the old path
                    string serverPath = hostingEnvironment.WebRootPath;
                    string oldPath = Path.Combine(serverPath, "images/profilePics/" + profilePic);

                    if (Directory.Exists(oldPath))
                    {
                        System.IO.File.SetAttributes(oldPath, FileAttributes.Normal);
                        System.IO.File.Delete(oldPath);
                    }

                    //Extract Image File Name.
                    string fileName = Path.GetFileName(pictureFile.FileName);

                    //Set the Image File Path.
                    string uploads = Path.Combine(hostingEnvironment.WebRootPath, "images/profilePics");
                    var filePath = Path.Combine(uploads, fileName);

                    //Save the Image File in Folder.
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }

                    user.ProfilePic = fileName;
                }

                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
                
            }

            return View();

        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

    }
}