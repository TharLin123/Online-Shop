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
            Session session = GetSession();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            Guid userid = session.UsersId;
            //the follow 2 lines of code are for testing only
            //Users user = dbContext.Users.FirstOrDefault(x => x.UserName.Equals("adam"));
            //Guid userid = user.Id;

            CreateOrder orderMaker = new CreateOrder(userid,dbContext);
            orderMaker.MakeOrder();//with passing the data to user/product/order/actcode tables, the his data in cartitem table will be deleted.
            return RedirectToAction("Index", "MyPurchase");
        }//check out function-----> put user's cartitem data into User/Product/Order table
       
        [Route("Cart")]
        public IActionResult ViewCart(List<Products> shoppingCart)
        {
            Session session = GetSession();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Guid userid = session.Users.Id;
            //Guid userid = new Guid();//for testing

            List<CartItem> cartItems = dbContext.CartItem.Where(x => x.UsersId == userid).ToList();
            ViewData["cart"] = cartItems;

            string userCartAmt = cartItems.Sum(x => x.Quantity * x.Product.UnitPrice).ToString();

            ViewData["userCartAmt"] = userCartAmt;

            return View();

        }

        public IActionResult Update([FromBody] UpdateCart values)
        {
            string username = Request.Cookies["Username"];
            Users user = dbContext.Users.FirstOrDefault(x => x.UserName == username);
            Guid userid = user.Id;
            int newquantity = values.Quantity;

            string userCartAmt;
                     
            //REMOVING THE ITEM FROM CART SHOULD HAVE A SEPARATE ACTION METHOD
            /*if (newquantity == 0) 
            {
                CartItem cartItem = dbContext.CartItem.FirstOrDefault(x => x.UsersId == userid && x.Product.ProductID == values.ProductId);

                dbContext.Remove(cartItem);
                dbContext.SaveChanges();

                userCartAmt = dbContext.CartItem.Where(x => x.UsersId == userid).Sum(x => x.Quantity * x.Product.UnitPrice).ToString();

                return Json(new 
                { status = "success", 
                  userCartAmt});
            } else
            {*/
                CartItem cartItem = dbContext.CartItem.FirstOrDefault(x => x.UsersId == userid && x.Product.ProductID == values.ProductId);

                if (cartItem != null)
                {
                    cartItem.Quantity = newquantity;
                }

                dbContext.SaveChanges();

                userCartAmt = dbContext.CartItem.Where(x => x.UsersId == userid).Sum(x => x.Quantity * x.Product.UnitPrice).ToString();

                return Json(new 
                { status = "success",
                  userCartAmt
                });
            /*}*/


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
