using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CATeam5Solution.Models;



namespace CATeam5Solution.Controllers
{
    public class SearchController : Controller
    {
        private DBContext dbContext;
        public SearchController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
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
                ViewData["AllProducts"] = allProducts;
                searchStr = "";
                return RedirectToAction("Index", "Home"); 

            }
            return View(); 
        }
    }
}
