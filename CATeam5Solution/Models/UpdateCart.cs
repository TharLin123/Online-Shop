using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// this is solely used for the binding of json data 

namespace CATeam5Solution.Models
{
    public class UpdateCart
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
