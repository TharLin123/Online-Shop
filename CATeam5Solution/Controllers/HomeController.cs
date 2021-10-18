using CATeam5Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CATeam5Solution.Controllers
{
    public class HomeController : Controller
    {
        private DBContext dbContext;
        public HomeController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //show all products on the Home page
        public IActionResult Index()
        {
            DB db = new DB(dbContext);
            List<Products> allProducts = dbContext.Products.ToList();
            ViewData["AllProducts"] = allProducts;

            return View(); 
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
