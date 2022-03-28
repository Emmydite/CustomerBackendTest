using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customer.DAL.Entities
{
   public class Customer //: IdentityUser<Guid>
    {
        public Guid CustomerId { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string PassWord { get; set; }
        public string StateOfResidence { get; set; }
        public string Lga { get; set; }
        public bool PhoneNumber_verified { get; set; } = false;
    }
}
