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
      
        //For testing only. 
        public IActionResult ViewCartTest()
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
        private DBContext dbContext;

        public CartController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewCart(List<Products> shoppingCart)
        {
            Session session = GetSession();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }

            /*List<Products> cart = shoppingCart;
            ViewData["cart"] = cart;
            return View();*/ //can remove this?

            Guid userid = session.UserId;

            List<CartItem> cartItems = dbContext.CartItem.Where(x => x.UsersId == userid).ToList();
            ViewData["cart"] = cartItems;
            return View();
        }

        private Session GetSession()
        {
            if (Request.Cookies["SessionId"] == null)
            {
                return null;
            }

            Guid sessionId = Guid.Parse(Request.Cookies["SessionId"]);
            Session session = dbContext.Session.FirstOrDefault(x =>
                x.Id == sessionId
            );

            return session;
        }


    }
}
