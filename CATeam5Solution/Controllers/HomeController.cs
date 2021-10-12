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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /* Hardcoding products as a list here first because
             * still not very sure how to implement the Seed() function 
             * and getting the data into Controller then View
             * (XH)
             */
           
            List<Products> allProducts = new List<Products>();

            allProducts.Add(new Products
            {
                ProductID = 1,
                Name = "PhotoEditShop",
                UnitPrice = 39.99,
                Description = "This app provides you with the capabilities to do professional design and photo editing!"
            });

            allProducts.Add(new Products
            {
                ProductID = 2,
                Name = "readPDF Pro",
                UnitPrice = 9.99,
                Description = "Pro Version of the readPDF! Allows you to edit, encrypt and Sign off in a pdf document!  "
            });

            allProducts.Add(new Products
            {
                ProductID = 3,
                Name = "ProPremier​",
                UnitPrice = 59.99,
                Description = "Premium version of the premier video editing application!  "
            });

            allProducts.Add(new Products
            {
                ProductID = 4,
                Name = "RoomLight​",
                UnitPrice = 39.99,
                Description = "A creative image manipulation software that allows you to create a workflow so ease your life as both an avid or pro photographer   "
            });

            allProducts.Add(new Products
            {
                ProductID = 5,
                Name = "EffectsAfter",
                UnitPrice = 69.99,
                Description = " VFX and Motion graphics software for the budding animators and 3d designers!  "
            });

            allProducts.Add(new Products
            {
                ProductID = 6,
                Name = "illustrator",
                UnitPrice = 69.99,
                Description = "the industry-standard vector graphics app that lets you create logos, icons, drawings, typography, and complex illustrations for any medium!  "
            });


            ViewData["AllProducts"] = allProducts;
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
