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
            //check order status and login status,both true, jump to this page
            //select specific order to check order details
            
            //Session session = GetSession();
            //if (session == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            /*Guid userid = session.UserId;*///when the login function is done
            Users user = dbContext.Users.FirstOrDefault(x => x.UserName.Equals("adam"));
            Guid userid = user.Id;

            List<Order> orders = dbContext.Orders.Where(x => x.UsersId.Equals(userid)).ToList();
            List<ActCode> actCodes = new List<ActCode>();
            List<Products> products = new List<Products>();
            foreach (Order order in orders)
            {
                foreach (ActCode actcode in order.ActCodes)
                {
                    actCodes.Add(actcode);//get all actcodes of him 获取他所有的Actcodes(从这里可以计算出单个商品有几个Actcode)
                }
                foreach (Products product in order.Products)
                {
                    if (!products.Contains(product))
                        products.Add(product);//get how many types of product he has bought 获取到他购买过几种商品(包括展示需要的各种信息)
                }
            }
            ////Get all orders of this user contains some list<product> need to put together to compute the total types of product/ total num of each product
            ////orderdate---->2021-10-13 21:02:00.6758862 
            ////actcode list for each product of this order
            ViewData["orders"] = orders;//主要从这里获取订单时间 可以展示该商品最后购买时间
            ViewData["actcodes"] = actCodes;
            ViewData["products"] = products;
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
