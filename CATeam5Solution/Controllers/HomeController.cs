using CATeam5Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CATeam5Solution.Controllers
{
    public class HomeController : Controller
    {
        /*Have to comment out the following HomeController default
         * Otherwise cannot put in DBContext and constructor
         * which then results in not being able to add all products 
         * to the list (XH)
         */
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private DBContext dbContext;
        public HomeController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        List<Products> shoppingCart = new List<Products>();
        public void AddToCart(int ProductId)
        {
           
        }

        public IActionResult Index()
        {
            List<Products> allProducts = dbContext.Products.ToList();
            
            ViewData["AllProducts"] = allProducts;
            ViewData["ShoppingCart"] = ShoppingCart.ProductList;
            return View(); // testing github
        }

        public IActionResult Privacy()
        {
            return View();
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
