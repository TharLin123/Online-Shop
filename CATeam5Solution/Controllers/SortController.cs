﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CATeam5Solution.Models;

namespace CATeam5Solution.Controllers
{
    public class SortController : Controller
    {

        private DBContext dbContext;
        public SortController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult SortAsce()
        {
            List<Products> allProducts = dbContext.Products.ToList();
            List<Products> priceAsce = allProducts.OrderBy(p => p.UnitPrice).ToList();

            ViewData["AllProducts"] = allProducts;
            ViewData["priceAsce"] = priceAsce;

            return View(); 
        }

        public IActionResult SortDesc()
        {

            List<Products> allProducts = dbContext.Products.ToList();
            List<Products> priceDesc = allProducts.OrderByDescending(p => p.UnitPrice).ToList();

            ViewData["AllProducts"] = allProducts;
            ViewData["priceDesc"] = priceDesc;

            return View(); 
        }

        public IActionResult SortNameA()
        {
            List<Products> allProducts = dbContext.Products.ToList();
            List<Products> nameA = allProducts.OrderBy(p => p.ProductName).ToList();

            ViewData["AllProducts"] = allProducts;
            ViewData["nameA"] = nameA;

            return View();
        }

        public IActionResult SortNameZ()
        {
            List<Products> allProducts = dbContext.Products.ToList();
            List<Products> nameZ = allProducts.OrderByDescending(p => p.ProductName).ToList();

            ViewData["AllProducts"] = allProducts;
            ViewData["nameZ"] = nameZ;

            return View();
        }
    }
}
