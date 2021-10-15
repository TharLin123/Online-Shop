using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CATeam5Solution.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CATeam5Solution.Controllers
{
    public class SearchController : Controller
    {
        private DBContext dbContext;
        public SearchController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index(string searchStr)
        {
            List<Products> allProducts = dbContext.Products.ToList();

            if (searchStr != null)
            {
                List<Products> products = dbContext.Products.Where(x =>
                x.ProductName.Contains(searchStr) ||
                x.Description.Contains(searchStr)).ToList();
                ViewData["AllProducts"] = products;
            }
            else
            {

                
                return RedirectToAction("Index", "Home"); //return to Gallery page if cleared

                //ViewData["AllProducts"] = allProducts;
                //ViewData["ShoppingCart"] = ShoppingCart.ProductList;
                //searchStr = "";

                ViewData["AllProducts"] = allProducts;
                searchStr = "";
            }


            return View(); // testing github
        }
    }
}
