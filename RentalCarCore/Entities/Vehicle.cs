using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCarCore.Entities
{
    public class Vehicle:BaseEntity
    {
        [Required]
        public int ModelID { get; set; }

        [Required]
        [StringLength(15)]
        public string Domain { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        [Required]
        public int UserIDCreation { get; set; }

        [ForeignKey("UserIDCreation")]
        public virtual User User { get; set; }

        [ForeignKey("ModelID")]
        public virtual VehicleModel Model { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
