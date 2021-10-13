using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Order
    {
        public Order()
        {
            Id = new Guid();
            OrderDate = DateTime.Now;
            Products = new List<Products>();
            ActCodes = new List<ActCode>();

        }

        
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        
        public virtual ICollection<ActCode> ActCodes { get; set; }
        public virtual Guid UsersId { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
