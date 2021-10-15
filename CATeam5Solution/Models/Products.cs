using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Products
    {

        public Products()
        {
            Id = new Guid();
            ActCodes = new List<ActCode>();
            Orders = new List<Order>();
<<<<<<< Updated upstream
            CartItems = new List<CartItem>();
=======
            ProductsShoppingCarts = new List<ProductsShoppingCart>();
>>>>>>> Stashed changes
        }
        
        public Guid Id { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        //1 to many between order and products
        //public virtual Guid OrderId { get; set; }

        //many 2 many relationship between Pro and Ord
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ActCode> ActCodes { get; set; }
        public virtual ICollection<ProductsShoppingCart> ProductsShoppingCarts { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
