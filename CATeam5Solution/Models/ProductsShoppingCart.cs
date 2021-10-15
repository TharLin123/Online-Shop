using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CATeam5Solution.Models
{
    public class ProductsShoppingCart
    {
        public ProductsShoppingCart()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public virtual Products Products { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
