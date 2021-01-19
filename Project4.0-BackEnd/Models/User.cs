using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project4._0_BackEnd.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public byte[] HashSalt { get; set; }
        public string Role { get; set; }
    }
}   
    