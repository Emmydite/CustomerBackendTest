using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Customer.BLL.Models
{
   public class CustomerModel
    {
        [JsonIgnore]
        public Guid CustomerId { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string PassWord { get; set; }
        public string StateOfResidence { get; set; }
        public string Lga { get; set; }

        [DefaultValue(false)]
        public bool IsPhoneVerified { get; set; }
    }
}
