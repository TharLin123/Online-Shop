using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CATeam5Solution.Models;
using CATeam5Solution.Method;

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
        public IActionResult CheckOut()
        {
            //Session session = GetSession();
            //if (session == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            ////To verify if he is login or not
            //Guid userid = session.UserId;
            //the follow 2 lines of code are for testing only
            Users user = dbContext.Users.FirstOrDefault(x => x.UserName.Equals("adam"));
            Guid userid = user.Id;

            CreateOrder orderMaker = new CreateOrder(userid,dbContext);
            orderMaker.MakeOrder();
            return RedirectToAction("Index", "MyPurchase");
        }//check out function-----> put user's cartitem data into User/Product/Order table
       
        [Route("Cart")]
        public IActionResult ViewCart(List<Products> shoppingCart)
        {
            //Session session = GetSession();
            //if (session == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            //Guid userid = session.UserId;
            Guid userid = new Guid();//for testing

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
