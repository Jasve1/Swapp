using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swapp.Data;
using Swapp.Models;

namespace Swapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppIdentityDbContext dataContext;
        private readonly UserManager<AppUser> userManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductController(AppIdentityDbContext context, UserManager<AppUser> userMgr, IHostingEnvironment environment)
        {
            dataContext = context;
            userManager = userMgr;
            hostingEnvironment = environment;
        }


        // GET: Products/Create
        [Authorize]
        public IActionResult Create(string category)
        {
            var categories = new List<SelectListItem>();

            List<Category> categoryList = dataContext.Category.ToList();

            foreach (var item in categoryList)
            {
                categories.Add(
                    new SelectListItem
                    {
                        Text = item.CategoryName,
                        Value = item.CategoryId.ToString(),
                        Selected = !string.IsNullOrEmpty(category) && item.CategoryName == category
                    }
                );
            }

            ViewData["Categories"] = categories;

            var userId = userManager.GetUserId(HttpContext.User);
            ViewBag.UserId = userId;

            return View();
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,PConditionId,PValueId,ProductDescription,ProductName,CategoryId,AspNetUserId")] Product product, 
            int category, List<IFormFile> pictureFile, string chooseCategory)
        {
            if (pictureFile == null || pictureFile.Count() == 0)
            {
                ModelState.AddModelError("", "Please upload an image");
            }
            if (ModelState.IsValid)
            {

            dataContext.Add(product);
            await dataContext.SaveChangesAsync();

            List<Image> dbFileNames = new List<Image>();
            string uploads = Path.Combine(hostingEnvironment.WebRootPath, "images/productImages");
            foreach (var formFile in pictureFile)
            {
                if (formFile.Length > 0)
                {
                    string fileName = Path.GetFileName(formFile.FileName);
                    var filePath = Path.Combine(uploads, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                    Image image = new Image()
                    {
                        ImageName = formFile.Name,
                        ImageUrl = formFile.FileName,
                        ProductId = product.ProductId
                    };
                    dbFileNames.Add(image);
                }
            }
            

            foreach (Image image in dbFileNames)
            {
                dataContext.Add(image);
                await dataContext.SaveChangesAsync();
            }

                return RedirectToAction("Index", "Home");


            }

            var categories = new List<SelectListItem>();

            List<Category> categoryList = dataContext.Category.ToList();

            foreach (var item in categoryList)
            {
                categories.Add(
                    new SelectListItem
                    {
                        Text = item.CategoryName,
                        Value = item.CategoryId.ToString(),
                        Selected = !string.IsNullOrEmpty(chooseCategory) && item.CategoryName == chooseCategory
                    }
                );
            }

            ViewData["Categories"] = categories;

            return View(product);
        }



        // GET: Products/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id, string category)
        {
            var categories = new List<SelectListItem>();

            List<Category> categoryList = dataContext.Category.ToList();

            foreach (var item in categoryList)
            {
                categories.Add(
                    new SelectListItem
                    {
                        Text = item.CategoryName,
                        Value = item.CategoryId.ToString(),
                        Selected = !string.IsNullOrEmpty(category) && item.CategoryName == category
                    }
                );
            }

            ViewData["Categories"] = categories;

            var userId = userManager.GetUserId(HttpContext.User);
            ViewBag.UserId = userId;

            if (id == null)
            {
                return NotFound();
            }

            var product = await dataContext.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,PConditionId,PValueId,ProductDescription,ProductName,CategoryId,AspNetUserId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(product);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await dataContext.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string serverPath = hostingEnvironment.WebRootPath;

            var product = await dataContext.Product.FindAsync(id);

            List<Image> images = dataContext.Image.Where(i => i.ProductId == product.ProductId).ToList();

            foreach (var i in images)
            {
                string imgPath = Path.Combine(serverPath, "images/profilePics/" + i.ImageUrl);
                System.IO.File.Delete(imgPath);
                dataContext.Remove(i);
            }

            dataContext.SaveChanges();

            dataContext.Product.Remove(product);
            await dataContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ProductExists(int id)
        {
            return dataContext.Product.Any(e => e.ProductId == id);
        }
    }
}