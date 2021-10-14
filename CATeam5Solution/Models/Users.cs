using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Users
    {
        public Users()
        {
            Id = new Guid();
            Order = new List<Order>();
            
        }
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        
        public string Email { get; set; }
        
        //1 to many between user and orders
        public virtual ICollection<Order> Order { get; set; }//每个user会有很多的Order

        public virtual ICollection<CartItem> CartItems { get; set; }
        
        
    }
}
