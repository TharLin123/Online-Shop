using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CATeam5Solution.Models;

namespace CATeam5Solution.Controllers
{
    public class CartController : Controller
    {
       [Route("/Cart")]
        //public IActionResult ViewCart(List<Products> productsAddedToCart)
        //{
        //    List<Products> cartProducts = productsAddedToCart;
        //    ViewData["cartProducts"] = cartProducts;
        //    return View();
        //}

        //For testing only. Actual method above, to take arguments in parameter
        public IActionResult ViewCart()
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
            return View();
        }


    }
}
