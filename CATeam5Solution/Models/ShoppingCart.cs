using System;
using System.Collections.Generic;
using CATeam5Solution.Models;

namespace CATeam5Solution.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartId = new Guid();
            ProductsShoppingCarts = new List<ProductsShoppingCart>();
        }

        public Guid ShoppingCartId { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<ProductsShoppingCart> ProductsShoppingCarts { get; set; }
    }
}
