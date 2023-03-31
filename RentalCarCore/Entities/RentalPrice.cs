using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCarCore.Entities
{
    public class RentalPrice:BaseEntity
    {
        [Required]
        public double PricePerDay { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public int ModelID { get; set; }

        [ForeignKey("ModelID")]
        public virtual VehicleModel Model { get; set; }
    }
}
