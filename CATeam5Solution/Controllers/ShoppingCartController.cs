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
            int Count = 0;
            Products ProductToAdd = dbContext.Products.FirstOrDefault(product => product.ProductID == id);

            Dictionary<string, int> ShoppingCartItem = ShoppingCart.ProductList.SingleOrDefault(product => product["ProductId"] == id);

            if (ShoppingCartItem != null)
            {
                ShoppingCartItem["Amount"] += 1;
            }
            else
            {
                Dictionary<string, int> ShoppingCartDict = new Dictionary<string, int>();
                ShoppingCartDict["ProductId"] = ProductToAdd.ProductID;
                ShoppingCartDict["Amount"] = 1;
                ShoppingCart.ProductList.Add(ShoppingCartDict);
            }

            foreach(Dictionary<string, int> Item in ShoppingCart.ProductList)
            {
                Count += Item["Amount"];
            }
            return Json(new { CartCount =  Count, ShoppingCart = ShoppingCart.ProductList});
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            int Count = 0;
            Products ProductToAdd = dbContext.Products.FirstOrDefault(product => product.ProductID == id);

            Dictionary<string, int> ShoppingCartItem = ShoppingCart.ProductList.SingleOrDefault(product => product["ProductId"] == id);

            if(ShoppingCartItem != null)
            {
                ShoppingCartItem["Amount"] -= 1;
                if (ShoppingCartItem["Amount"] == 0)
                {
                    ShoppingCart.ProductList.Remove(ShoppingCartItem);
                }
            }

            foreach (Dictionary<string, int> Item in ShoppingCart.ProductList)
            {
                Count += Item["Amount"];
            }
            return Json(new { CartCount = Count, ShoppingCart = ShoppingCart.ProductList });
        }
    }
}
