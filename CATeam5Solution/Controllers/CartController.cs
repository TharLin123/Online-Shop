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

        private DBContext dbContext;

        public CartController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Cart")] // Route here first to test view
        public IActionResult ViewCart()
        {
            Dictionary<string, int> ShoppingCartDict = new Dictionary<string, int>();
            ShoppingCartDict.Add("1", 3);
            ShoppingCartDict.Add("2", 4);
            ShoppingCartDict.Add("3", 1);

            Dictionary<Products, int> ShoppingCartDictReal = new Dictionary<Products, int>();
            foreach (var item in ShoppingCartDict)
            {
                int id = Int32.Parse(item.Key);
                //Change to fetch from DB instead
                Products ProductToAdd = ProductList.ProductsListt.SingleOrDefault(r => r.ProductID == id);
                ShoppingCartDictReal.Add(ProductToAdd, item.Value);
            }

            ViewData["ShoppingCartDict"] = ShoppingCartDictReal;
            ViewData["TestImage"] = "/img/Behance-64.png"; //seed product image. need to add in products model.
            return View();
        }


            public IActionResult ViewCart(List<Products> shoppingCart)
        {
            Session session = GetSession();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }

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
