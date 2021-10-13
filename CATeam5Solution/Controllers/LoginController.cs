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

            Response.Cookies.Append("SessionId", session.Id.ToString());
            Response.Cookies.Append("Username", user.UserName);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {

            Response.Cookies.Delete("SessionId");
            Response.Cookies.Delete("Username");

            return RedirectToAction("Index");
        }

        public IActionResult CreateAccount()
        {

            return View();

        }
        public IActionResult RegisterAccount(IFormCollection form)
        {
            string username = form["username"].ToString();
            string password = form["confirmPass"].ToString();
            Users user = dbContext.Users.FirstOrDefault(x =>
            x.UserName == username);

            if (user != null)
            {
                return RedirectToAction("UserExist", "Login");
            }
            HashAlgorithm sha = SHA256.Create();
            byte[] hashpass = sha.ComputeHash(Encoding.UTF8.GetBytes(username + password));

            dbContext.Add(new Users
            {
                UserName = username,
                Password = hashpass
            });
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}

