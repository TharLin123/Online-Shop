using CATeam5Solution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Method
{
    public class TestSeedOnly
    {
        private DBContext dBContext;
        // test userName adam
        public TestSeedOnly(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void Seed()
        {
            MakeOrders();
        }

        public void MakeOrders()
        {

            //find the product first
            Products pro1 = dBContext.Products.FirstOrDefault(x => x.ProductID == 1);
            Products pro2 = dBContext.Products.FirstOrDefault(x => x.ProductID == 2);
            Products pro3 = dBContext.Products.FirstOrDefault(x => x.ProductID == 3);
            Products pro4 = dBContext.Products.FirstOrDefault(x => x.ProductID == 4);
            Products pro5 = dBContext.Products.FirstOrDefault(x => x.ProductID == 5);
            Products pro6 = dBContext.Products.FirstOrDefault(x => x.ProductID == 6);
            
           
            //find the user
            Users adam = dBContext.Users.FirstOrDefault(x => x.UserName == "adam");
            
            if (adam != null)
            {
                Order adamOrder1 = new Order();
                adam.Order.Add(adamOrder1);
                pro1.Orders.Add(adamOrder1);
                pro1.Orders.Add(adamOrder1);
                pro2.Orders.Add(adamOrder1);
                pro3.Orders.Add(adamOrder1);
                pro4.Orders.Add(adamOrder1);
                       
            }
            dBContext.SaveChanges();
            //find the order of adam then create the Actcodes for him
            Order adamOrderAct = dBContext.Orders.FirstOrDefault(x => x.UsersId.Equals(adam.Id));
            if (adamOrderAct != null)
            {
                ActCode order1pro1act1 = new ActCode();
                ActCode order1pro1act2 = new ActCode();
                ActCode order1pro2act1 = new ActCode();
                ActCode order1pro3act1 = new ActCode();
                ActCode order1pro4act1 = new ActCode();

                adamOrderAct.ActCodes.Add(order1pro1act1);
                adamOrderAct.ActCodes.Add(order1pro1act2);
                adamOrderAct.ActCodes.Add(order1pro2act1);
                adamOrderAct.ActCodes.Add(order1pro3act1);
                adamOrderAct.ActCodes.Add(order1pro4act1);
                pro1.ActCodes.Add(order1pro1act1);
                pro1.ActCodes.Add(order1pro1act2);
                pro2.ActCodes.Add(order1pro2act1);
                pro3.ActCodes.Add(order1pro3act1);
                pro4.ActCodes.Add(order1pro4act1);
            }

            dBContext.SaveChanges();




        }
    }
}
