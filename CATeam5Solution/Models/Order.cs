﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Order
    {
        public Order()
        {
            Id = new Guid();
            Products = new List<Products>();
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Guid UsersId { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
