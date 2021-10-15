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
       private DBContext dbContext;
        public MyPurchaseController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //check order status and login status, both true, jump to this page
            // select specific order to check order details

            Session session = GetSession();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Guid userid = session.UsersId;//get user's Guid
            //the following 2 lines are for testing only
            //Users user = dbContext.Users.FirstOrDefault(x => x.UserName.Equals("adam"));
            //Guid userid = user.Id;
            GetMyPurchaseData myPurchaseMaker = new GetMyPurchaseData(userid, dbContext);
            List<MyPurchaseViewModel> myPurchaseViewModels = myPurchaseMaker.MakeMyPurchaseView();
            ViewData["myPurchaseViewModel"] = myPurchaseViewModels;

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
        //Copy CartItem controller's code
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
