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
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            ShoppingCart.ProductList.Add();
            return Json(new { CartCount = ShoppingCart.ProductList.Count });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            Products ProductToRemove = ShoppingCart.ProductList.SingleOrDefault(r => r.ProductID == id);
            ShoppingCart.ProductList.Remove(ProductToRemove);
            return Json(new { CartCount = ShoppingCart.ProductList.Count });
        }
    }
}
