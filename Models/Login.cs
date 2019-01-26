using System;
using System.ComponentModel.DataAnnotations;

namespace aureliadotnet.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}