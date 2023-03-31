using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentalCarCore.Entities
{
    public class Customer: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string IdCard { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [Required]
        [StringLength(300)]
        public string Direction { get; set; }
        [Required]
        public DateTime DateRegistered { get; set; }


        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
