using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            ActivationCode = new Guid();
           
        }
        public Guid ActivationCode { get; set; }

        public virtual Order Order { get; set;}

      



    }
}
