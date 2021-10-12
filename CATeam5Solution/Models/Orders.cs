using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Orders
    {
        public Orders()
        {
            ActivationCode = new Guid();
            Products = new List<Products>();
            Users = new List<Users>();
        }
        public Guid ActivationCode { get; set; }

        public ICollection<Products> Products { get; set; }
        public ICollection<Users> Users { get; set; }



    }
}
