using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CATeam5Solution.Models;

namespace CATeam5Solution.Controllers
{
    public class CartTestController : Controller 
    {

       //For testing view only. 
        public IActionResult Index()
        {
            List<Products> testList = new List<Products>
            {
                new Products
                {
                    ProductID = 1,
                    ProductName = "PhotoEditShop",
                    UnitPrice = 39.99,
                    Description = "This app provides you with the capabilities to do professional design and photo editing!"
                 },

                new Products
                {
                    ProductID = 3,
                    ProductName = "ProPremier​",
                    UnitPrice = 59.99,
                    Description = "Premium version of the premier video editing application!"
                }
            };
            List<Products> cartProducts = testList;
            ViewData["cartProducts"] = cartProducts;
            ViewData["TestImage"] = "~/img/Behance-64.png"; //seed product image. need to add in products model.
            return View();
        }
    }
}
