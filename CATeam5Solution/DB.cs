using CATeam5Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            SeedUsers();
        }

        public void SeedProducts()
        {
            dbContext.Add(new Products
            {
                ProductID = 1,
                ProductName = "PhotoEditShop",
                UnitPrice = 39,
                Description = "This app provides you with the capabilities to do professional design and photo editing!",
                Image = "Photoshop.png"
            });
            dbContext.Add(new Products
            {
                ProductID = 2,
                ProductName = "readPDF Pro",
                UnitPrice = 9,
                Description = "Pro Version of the readPDF! Allows you to edit, encrypt and Sign off in a pdf document!",
                Image = "AcrobatDC.png"
            });
            dbContext.Add(new Products
            {
                ProductID = 3,
                ProductName = "ProPremier​",
                UnitPrice = 59,
                Description = "Premium version of the premier video editing application!",
                Image = "Premiere.png"
            });

            dbContext.Add(new Products
            {
                ProductID = 4,
                ProductName = "RoomLight​",
                UnitPrice = 39,
                Description = "A creative image manipulation software that allows you to create a workflow so ease your life as both an avid or pro photographer",
                Image = "Lightroom.png"
            });
            dbContext.Add(new Products
            {
                ProductID = 5,
                ProductName = "EffectsAfter",
                UnitPrice = 69,
                Description = " VFX and Motion graphics software for the budding animators and 3d designers!",
                Image = "AfterEffects.png"
            });

            dbContext.Add(new Products
            {
                ProductID = 6,
                ProductName = "illustrator",
                UnitPrice = 69,
                Description = "the industry-standard vector graphics app that lets you create logos, icons, drawings, typography, and complex illustrations for any medium!",
                Image = "Illustrator.png"
            });
            dbContext.SaveChanges();
        }

        public void SeedUsers()
        {
            HashAlgorithm sha = SHA256.Create();

            string[] usernames = { "adam", "betty", "charles", "daniel", "elson", "hehehe" };

            foreach (string username in usernames)
            {
                string combo = username + username;
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(combo));

                dbContext.Add(new Users
                {
                    UserName = username,
                    Password = hash,
                    Email = "123@123.com"
                });
            }

            dbContext.SaveChanges();
        }

    }
}

