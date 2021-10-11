using CATeam5Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution
{
    public class DB
    {
        private DBContext dbContext;

        public DB(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            SeedProducts();
        }


        public void SeedProducts()
        {
            dbContext.Add(new Products
            {
                ProductID = 1,
                Name = "PhotoEditShop",
                UnitPrice = 39.99,
                Description = "This app provides you with the capabilities to do professional design and photo editing!"
            });
            dbContext.Add(new Products
            {
                ProductID = 2,
                Name = "readPDF Pro",
                UnitPrice = 9.99,
                Description = "Pro Version of the readPDF! Allows you to edit, encrypt and Sign off in a pdf document!  "
            });
            dbContext.Add(new Products
            {
                ProductID = 3,
                Name = "ProPremier​",
                UnitPrice = 59.99,
                Description = "Premium version of the premier video editing application!  "
            });

            dbContext.Add(new Products
            {
                ProductID = 4,
                Name = "RoomLight​",
                UnitPrice = 39.99,
                Description = "A creative image manipulation software that allows you to create a workflow so ease your life as both an avid or pro photographer   "
            });
            dbContext.Add(new Products
            {
                ProductID = 5,
                Name = "EffectsAfter",
                UnitPrice = 69.99,
                Description = " VFX and Motion graphics software for the budding animators and 3d designers!  "
            });

            dbContext.Add(new Products
            {
                ProductID = 6,
                Name = "illustrator",
                UnitPrice = 69.99,
                Description = "the industry-standard vector graphics app that lets you create logos, icons, drawings, typography, and complex illustrations for any medium!  "
            });
        }

            
    }
}
