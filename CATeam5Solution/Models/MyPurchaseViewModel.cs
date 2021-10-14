using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class MyPurchaseViewModel
    {
        public DateTime DateTime { get; set; }//Please pick the first one as the latest date
        public string ImageLink { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public List<string> ActivationCode { get; set; }
        public int ProductId { get; set; }

    }
}
