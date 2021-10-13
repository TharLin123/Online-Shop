using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Review
    {
        public Review()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Grade { get; set; }
        public DateTime ReviewDate { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
