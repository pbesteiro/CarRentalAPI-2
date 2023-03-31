using System;
namespace CarRentalCore.Requests
{
    public class AvailableVehiclesRequest
    {   
        /// <summary>
        /// Date since the rent starts
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Date to the rent ends
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Type Vehicle identifier
        /// </summary>
        public int? VehicleTypeId { get; set; }
    }
}
