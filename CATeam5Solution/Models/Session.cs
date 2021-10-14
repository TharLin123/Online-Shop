using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Session
    {
        public Session()
        {
            Id = new Guid();
            
        }

        public Guid Id { get; set; }

        public virtual Guid UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}
