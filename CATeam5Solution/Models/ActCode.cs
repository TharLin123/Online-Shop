using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class ActCode
    {
        public ActCode()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual Guid ProductsId { get; set; }
        
        
    }
    
}
