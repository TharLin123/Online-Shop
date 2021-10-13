using CATeam5Solution.Method;
using CATeam5Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Controllers
{
    public class MyPurchaseController : Controller
    {
       private readonly DBContext dbContext;
        public MyPurchaseController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
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
            //在这里获取View中需要的所有数据
           
            string userId = "7781ce81-5140-42d0-b914-08d98e31bbc4";//test only
            GetHistory getHistory = new GetHistory(userId, dbContext);
            ViewData["orders"] = getHistory.Orders;
            return View();
        }//for testing the page only now
        public IActionResult Review()
        {

            return View();
        }
    }
}
