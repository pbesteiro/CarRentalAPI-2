using System;
using System.ComponentModel.DataAnnotations;

namespace RentalCarCore.Entities
{
    public class User:BaseEntity
    {

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string UserName { get; set; }

        [Required]
        [StringLength(300)]
        public string Password { get; set; }
        [Required]
        [StringLength(300)]
        public string Salt { get; set; }
    }
}
