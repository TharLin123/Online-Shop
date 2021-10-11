using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CATeam5Solution.Models
{
    public class Users
    {
        public Users()
        {
            ID = new Guid();
        }
        public Guid ID { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }


        
    }
}
