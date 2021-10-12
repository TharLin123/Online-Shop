using CATeam5Solution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CATeam5Solution.Controllers
{
    public class LoginController : Controller
    {
        private DBContext dbContext;

        public LoginController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["SessionId"] != null)
            {
                Guid sessionId = Guid.Parse(Request.Cookies["sessionId"]);
                Session session = dbContext.Session.FirstOrDefault(x =>
                    x.Id == sessionId
                );

                if (session == null)
                {
                    return RedirectToAction("Index", "Logout");
                }

                
                return RedirectToAction("Index", "Home");
            }

         
            return View();
        }

        public IActionResult Login(IFormCollection form)
        {
            string username = form["username"];
            string password = form["password"];

            HashAlgorithm sha = SHA256.Create();
            byte[] hash = sha.ComputeHash(
                Encoding.UTF8.GetBytes(username + password));

            Users user = dbContext.Users.FirstOrDefault(x =>
                x.UserName == username &&
                x.Password == hash
            );

            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // create a new session and tag to user
            Session session = new Session()
            {
                UserName = user
            };
            dbContext.Session.Add(session);
            dbContext.SaveChanges();

            //Saving Cookies on browser
            Response.Cookies.Append("SessionId", session.Id.ToString());
            Response.Cookies.Append("Username", user.UserName);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            // ask client to remove these cookies so that
            // they won't be sent over next time
            Response.Cookies.Delete("SessionId");
            Response.Cookies.Delete("Username");

            return RedirectToAction("Index");
        }
    }
}

