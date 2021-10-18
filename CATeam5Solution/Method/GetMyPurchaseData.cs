using CATeam5Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Method
{
    public class GetMyPurchaseData
    {
        private DBContext dBContext;
        public GetMyPurchaseData(Guid userId, DBContext dBContext)
        {
            this.dBContext = dBContext;
            UserId = userId;
        }
        public Guid UserId { get; set; }
        public List<MyPurchaseViewModel> MakeMyPurchaseView()
        {
            List<MyPurchaseViewModel> myPurchaseData = new List<MyPurchaseViewModel>();
            List<Order> orders = dBContext.Orders.Where(x => x.UsersId.Equals(UserId)).ToList();
            List<ActCode> actCodes = new List<ActCode>();
            List<Products> products = new List<Products>();
            foreach (Order order in orders)
            {
                foreach (ActCode actcode in order.ActCodes)
                {
                    actCodes.Add(actcode);//get all actcodes of user
                }
                foreach (Products product in order.Products)
                {
                    if (!products.Contains(product))
                        products.Add(product);//get how many types of product user has bought
                }
            }
            foreach (Products pro in products)
            {
                int productId = pro.ProductID;
                string productName = pro.ProductName;
                string desc = pro.Description;
                string imagelink = pro.Image;
                List<string> codeList = new List<string>();
                int quantity = 0;
                List<DateTime> dateTime = new List<DateTime>();
                foreach (ActCode code in actCodes)
                {
                    if (code.ProductsId == pro.Id)
                    {
                        string oneActCode = code.Id.ToString();
                        codeList.Add(oneActCode);
                        quantity++;
                    }
                }
                foreach (Order order in orders)
                {
                    if (order.Products.Contains(pro))
                    {
                        dateTime.Add(order.OrderDate);
                    }
                }
                dateTime.Sort();
                dateTime.Reverse();
                myPurchaseData.Add(new MyPurchaseViewModel
                {
                    DateTime = dateTime[0],
                    ImageLink = imagelink,
                    Name = productName,
                    Quantity = quantity,
                    Description = desc,
                    ActivationCode = codeList
                }) ;
            }
            return myPurchaseData;
        }

    }
}

