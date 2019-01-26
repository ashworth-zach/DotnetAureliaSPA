using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace aureliadotnet.Models
{
    public class Register
    {

        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string firstname { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(45)]

        public string lastname { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(45)]

        public string alias { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(45)]

        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(55)]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string password { get; set; }
                [NotMapped]
        [Compare("password")]
        [DataType(DataType.Password)]
        [MaxLength(55)]

        public string Confirm { get; set; }
    }
}