using CATeam5Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Method
{
    public class CreateOrder
    {
        private DBContext createOrderDB;
        public CreateOrder(Guid userId,DBContext dBContext)
        {
            createOrderDB = dBContext;
            UserId = userId;
        }
        public Guid UserId { get; set; }
        public void MakeOrder()
        {
            Dictionary<Products,int> orderDetail =  FindProducts();
            NewOrder(orderDetail);
            
        }

        private Dictionary<Products, int> FindProducts()
        {
            List<CartItem> cart = createOrderDB.CartItem.Where(x => x.UsersId == this.UserId).ToList();//Find all CartItem of user
            Dictionary<Products, int> productDetail = new Dictionary<Products, int>();//new dict to store product with its quantity
            foreach (var item in cart)
            {
                productDetail.Add(item.Product, item.Quantity);
                createOrderDB.Remove(item);
            }
            return productDetail;
        }
        private void NewOrder(Dictionary<Products, int> productDetail)
        {
            Order order = new Order { 
                UsersId = this.UserId,
            };//new order object
            foreach (var item in productDetail) // for each key value pair in the dict(product,quantity)
            {
                for (int i = 0; i < item.Value; i++)//loop qunantity time to add all the products in his cart to the order.Products(List)
                {
                    order.Products.Add(item.Key);//add the product to order.products (list) 
                    ActCode actcode = new ActCode();//for each product, create a new ActCode
                    item.Key.Orders.Add(order);//add the Order to the product.Orders (List)
                    item.Key.ActCodes.Add(actcode);// add the actcode to the products.actcode (list)
                    order.ActCodes.Add(actcode);// add the actcode to the order.actcode (list)
                }
            }
            createOrderDB.SaveChanges();
        }
    }
}
