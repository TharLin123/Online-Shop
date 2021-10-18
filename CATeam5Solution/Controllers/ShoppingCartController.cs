using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CATeam5Solution.Models;

namespace CATeam5Solution.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DBContext dbContext;
        public ShoppingCartController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            string sesessionId = Request.Cookies["SessionId"];
            if (string.IsNullOrEmpty(sesessionId)) return Redirect("/Login");
            Users User = dbContext.Session.FirstOrDefault(session => session.Id.ToString() == sesessionId).Users;
            Products ProductToAdd = dbContext.Products.FirstOrDefault(product => product.ProductID == id);
            CartItem cartItem = dbContext.CartItem.FirstOrDefault(cartItem => cartItem.Users.Id == User.Id && cartItem.Product.ProductID == ProductToAdd.ProductID);
          
            if (cartItem == null)
            {
                dbContext.Add(new CartItem
                {
                    Users = User,
                    Product = ProductToAdd,
                    Quantity = 1,
                });
            }
            else
            {
                cartItem.Quantity += 1;
            }

            dbContext.SaveChanges();
            cartItem = dbContext.CartItem.FirstOrDefault(cartItem => cartItem.Users.Id == User.Id && cartItem.Product.ProductID == ProductToAdd.ProductID);
            List<CartItem> cartItems = dbContext.CartItem.Where(cartItem => cartItem.Users.Id == User.Id).ToList();
            int TotalItemInCart = 0;
            foreach(CartItem item in cartItems)
            {
                TotalItemInCart += item.Quantity;
            }
            return Json(new { TotalItem = TotalItemInCart, ItemCount = cartItem.Quantity });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            string sesessionId = Request.Cookies["SessionId"];
            if (string.IsNullOrEmpty(sesessionId)) return Redirect("/Login");
            Users User = dbContext.Session.FirstOrDefault(session => session.Id.ToString() == sesessionId).Users;
            Products ProductToRemove = dbContext.Products.FirstOrDefault(product => product.ProductID == id);
    
            CartItem cartItem = dbContext.CartItem.FirstOrDefault(cartItem => cartItem.Users.Id == User.Id && cartItem.Product.ProductID == ProductToRemove.ProductID);
            if (cartItem != null)
            {
                cartItem.Quantity -= 1;
                if (cartItem.Quantity == 0)
                {
                    dbContext.CartItem.Remove(cartItem);
                }
            }

            dbContext.SaveChanges();
            List<CartItem> cartItems = dbContext.CartItem.Where(cartItem => cartItem.Users.Id == User.Id).ToList();
            int TotalItemInCart = 0;
            foreach (CartItem item in cartItems)
            {
                TotalItemInCart += item.Quantity;
            }
            return Json(new { TotalItem = TotalItemInCart, ItemCount = cartItem.Quantity });
        }
    }
}
