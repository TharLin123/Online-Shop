using CATeam5Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Method
{
    public class GetHistory
    {
        private DBContext dbContext;
        public GetHistory(Guid userID, DBContext dbContext)
        {
            UserId = userID;
            this.dbContext = dbContext;
            Orders = GetOrders();
        }
        public Guid UserId { get; set; }
        public List<Order> Orders { get; set; }
        public List<Order> GetOrders()
        {
            List<Order> orders = dbContext.Orders.Where(x => x.UsersId == this.UserId).ToList();
            return orders;
            
        }
    }
}
