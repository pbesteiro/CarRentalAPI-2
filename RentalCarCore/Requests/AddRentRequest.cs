using System;

namespace CarRentalCore.Requests
{
    public class AddRentRequest
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
        /// Vehicle to rent's identifier
        /// </summary>
        public int VehicleID { get; set; }


        /// <summary>
        /// Customer's identifier
        /// </summary>
        public int CustomerID { get; set; }
    }
}
