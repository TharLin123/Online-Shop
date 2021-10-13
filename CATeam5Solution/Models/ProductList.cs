using System;
using System.Collections.Generic;

namespace CATeam5Solution.Models
{
    public class ProductList
    {
        public static List<Products> ProductsListt = new List<Products>()
        {
            new Products
            {
                ProductID = 1,
                ProductName = "PhotoEditShop",
                UnitPrice = 39.99,
                Description = "This app provides you with the capabilities to do professional design and photo editing!"
            },
            new Products
            {
                ProductID = 2,
                ProductName = "readPDF Pro",
                UnitPrice = 9.99,
                Description = "Pro Version of the readPDF! Allows you to edit, encrypt and Sign off in a pdf document!  "
            },
            new Products
            {
                ProductID = 3,
                ProductName = "ProPremier​",
                UnitPrice = 59.99,
                Description = "Premium version of the premier video editing application!  "
            },
            new Products
            {
                ProductID = 4,
                ProductName = "RoomLight​",
                UnitPrice = 39.99,
                Description = "A creative image manipulation software that allows you to create a workflow so ease your life as both an avid or pro photographer   "
            },
            new Products
            {
                ProductID = 5,
                ProductName = "EffectsAfter",
                UnitPrice = 69.99,
                Description = " VFX and Motion graphics software for the budding animators and 3d designers!  "
            },
            new Products
            {
                ProductID = 6,
                ProductName = "illustrator",
                UnitPrice = 69.99,
                Description = "the industry-standard vector graphics app that lets you create logos, icons, drawings, typography, and complex illustrations for any medium!  "
            },
            new Products
            {
                ProductID = 7,
                ProductName = "IPhone",
                UnitPrice = 900.99,
                Description = "the industry-standard vector graphics app that lets you create logos, icons, drawings, typography, and complex illustrations for any medium!  "
            }
        };
    }
}
