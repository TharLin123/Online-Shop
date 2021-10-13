using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Products
    {

        public Products()
        {
            Id = new Guid();
            Orders = new List<Order>();
            ActCodes = new List<ActCode>();
        }
        public Guid Id { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        //1 to many between order and products
        //public virtual Guid OrderId { get; set; }

        //many 2 many relationship between Pro and Ord
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ActCode> ActCodes { get; set; }//每个Product有很多的Actcode
        
    }
}
