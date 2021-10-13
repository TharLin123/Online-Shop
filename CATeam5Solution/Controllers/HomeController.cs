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
            /*Sorry hardcoding the products as a list here first
             * because still trying to figure out the database part
             * (XH)
             */
            List<Products> allProducts = new List<Products>();

            allProducts.Add(new Products
            {
                ProductID = 1,
                ProductName = "PhotoEditShop",
                UnitPrice = 39.99,
                Description = "This app provides you with the capabilities to do professional design and photo editing!"
            });

            allProducts.Add(new Products
            {
                ProductID = 2,
                ProductName = "readPDF Pro",
                UnitPrice = 9.99,
                Description = "Pro Version of the readPDF! Allows you to edit, encrypt and Sign off in a pdf document!  "
            });

            allProducts.Add(new Products
            {
                ProductID = 3,
                ProductName = "ProPremier​",
                UnitPrice = 59.99,
                Description = "Premium version of the premier video editing application!  "
            });

            allProducts.Add(new Products
            {
                ProductID = 4,
                ProductName = "RoomLight​",
                UnitPrice = 39.99,
                Description = "A creative image manipulation software that allows you to create a workflow so ease your life as both an avid or pro photographer   "
            });

            allProducts.Add(new Products
            {
                ProductID = 5,
                ProductName = "EffectsAfter",
                UnitPrice = 69.99,
                Description = " VFX and Motion graphics software for the budding animators and 3d designers!  "
            });

            allProducts.Add(new Products
            {
                ProductID = 6,
                ProductName = "illustrator",
                UnitPrice = 69.99,
                Description = "the industry-standard vector graphics app that lets you create logos, icons, drawings, typography, and complex illustrations for any medium!  "
            });
            

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
