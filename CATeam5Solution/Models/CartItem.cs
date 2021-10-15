using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        
        public int Quantity { get; set; }
        public virtual Users Users { get; set; }
        public virtual Guid UsersId { get; set; }
        public virtual Products Product { get; set; }
        
    }
}
