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
            CartItems = new List<CartItem>();
        }
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
