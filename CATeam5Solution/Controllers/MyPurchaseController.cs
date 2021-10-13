using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Controllers
{
    public class MyPurchaseController : Controller
    {
        public IActionResult Index()
        {
            //check order status and login status,both true, jump to this page
            //select specific order to check order details
            return View();
        }
        public IActionResult Details()
        {
            //Show orderId, ordertotal, email, phonenumber, orderDate, which account, coupon or not, activation code and something else?
            //have function to delete orders
            return View();
        }

        public IActionResult MyPurchase()
        {
            return View();
        }//for testing the page only now
        public IActionResult Review()
        {

            return View();
        }
    }
}
