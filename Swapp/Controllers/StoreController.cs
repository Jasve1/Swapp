using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swapp.Data;
using Swapp.Models;

namespace Swapp.Controllers
{
    public class StoreController : Controller
    {
        private AppIdentityDbContext dataContext;
        private readonly UserManager<AppUser> userManager;

        public StoreController(AppIdentityDbContext idDbContet, UserManager<AppUser> userMgr)
        {
            dataContext = idDbContet;
            userManager = userMgr;
        }

        //GetProducts
        [Authorize]
        public ActionResult Index(string category, string productListItem)
        {

            var userId = userManager.GetUserId(HttpContext.User);
            ViewBag.UserId = userId;

            List<Product> products = new List<Product>();

            List<Product> productObjects = dataContext.Product.Where(p => p.AspNetUserId != userId)
                .Include(p => p.Category).Include(p => p.AspNetUser).Include(p => p.Images).ToList();


            foreach (Product p in productObjects)
            {
                Product product = new Product()
                {
                    ProductId = p.ProductId,
                    ProductDescription = p.ProductDescription,
                    ProductName = p.ProductName,
                    CategoryId = p.CategoryId,
                    AspNetUserId = p.AspNetUserId,
                    AspNetUser = p.AspNetUser,
                    Category = p.Category,
                    Images = p.Images
                };
                products.Add(product);
            }


            var storeProducts = products.Where(p => category == null || p.Category.CategoryName == category)
                    .OrderBy(p => p.ProductId).ToList();

            var productDropDownList = new List<SelectListItem>();
            List<Product> productsOfCurrentUser = dataContext.Product.Where(p => p.AspNetUserId == userId).ToList();
            foreach (Product p in productsOfCurrentUser)
            {
                productDropDownList.Add(
                    new SelectListItem
                    {
                        Text = p.ProductName,
                        Value = p.ProductId.ToString(),
                        Selected = !string.IsNullOrEmpty(productListItem) && p.ProductName == productListItem
                    }
                );
            }
            ViewBag.ProductDropDownList = productDropDownList;


            return View(storeProducts);

        }
    }
}