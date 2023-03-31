using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCarCore.Entities
{
    public class VehicleModel : BaseEntity
    {

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public int Seats { get; set; }
        [Required]
        public bool Trunk { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public int Airbags { get; set; }
        [Required]
        public int BrandID { get; set; }

        [Required]
        public int VehicleTypeID { get; set; }

        [ForeignKey("BrandID")]
        public virtual VehicleBrand Brand { get; set; }

        [ForeignKey("VehicleTypeID")]
        public virtual VehicleType VehicleType { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<RentalPrice> Prices { get; set; }

    }
}
