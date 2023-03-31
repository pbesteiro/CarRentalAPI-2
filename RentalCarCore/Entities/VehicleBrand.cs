using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCarCore.Entities
{
    public class VehicleBrand : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public virtual ICollection<VehicleModel> Models { get; set; }
    }
}
