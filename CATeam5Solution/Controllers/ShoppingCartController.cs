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
            Users User = dbContext.Session.FirstOrDefault(session => session.Id.ToString() == Request.Cookies["sessionId"]).Users;
            Products ProductToAdd = dbContext.Products.FirstOrDefault(product => product.ProductID == id);

            ShoppingCart shoppingCart = dbContext.ShoppingCart.FirstOrDefault(cart => cart.User.Id == User.Id);

            if (shoppingCart == null)
            {
                dbContext.Add(new ShoppingCart
                {
                    User = User
                });
                dbContext.SaveChanges();
                shoppingCart = dbContext.ShoppingCart.FirstOrDefault(cart => cart.User == null);
            }

            dbContext.Add(new ProductsShoppingCart
            {
                Products = ProductToAdd,
                ShoppingCart = shoppingCart
            });

            CartItem cartItem = dbContext.CartItem.FirstOrDefault(cartItem => cartItem.Users.Id == User.Id && cartItem.Product.ProductID == ProductToAdd.ProductID);
          
            if (cartItem == null)
            {
                dbContext.Add(new CartItem
                {
                    Users = User,
                    Product = ProductToAdd,
                    Quantity = 1,
                }); 
            } else {
                cartItem.Quantity += 1;
            }

            dbContext.SaveChanges();

            List<ProductsShoppingCart> productsShoppingCart = dbContext.ProductsShoppingCart.Where(psc => psc.ShoppingCart == shoppingCart).ToList();
            int ItemCount = productsShoppingCart.Count(psc => psc.Products.ProductID == id);
            int TotalItem = productsShoppingCart.Count();
            return Json(new { TotalItem = TotalItem, ItemCount = ItemCount });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            Users User = dbContext.Session.FirstOrDefault(session => session.Id.ToString() == Request.Cookies["sessionId"]).Users;
            Products ProductToRemove = dbContext.Products.FirstOrDefault(product => product.ProductID == id);
            ShoppingCart shoppingCart = dbContext.ShoppingCart.FirstOrDefault(cart => cart.User.Id == User.Id);
            
            if (shoppingCart != null)
            {
                ProductsShoppingCart ShoppingCartItem = dbContext.ProductsShoppingCart.FirstOrDefault(psc => psc.Products.ProductID == id);
                if (ShoppingCartItem != null)
                {
                    dbContext.Remove(ShoppingCartItem);
                }
            }
      
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
            List<ProductsShoppingCart> productsShoppingCart = dbContext.ProductsShoppingCart.Where(psc => psc.ShoppingCart == shoppingCart).ToList();
            int ItemCount = productsShoppingCart.Count(psc => psc.Products.ProductID == id);
            int TotalItem = productsShoppingCart.Count();
            return Json(new { TotalItem = TotalItem, ItemCount = ItemCount });
        }
    }
}
