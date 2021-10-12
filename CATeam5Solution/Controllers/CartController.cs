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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewCart(List<Products> shoppingCart)
        {
            List<Products> cart = shoppingCart;
            ViewData["cart"] = cart;
            return View();
        }
    }
}
