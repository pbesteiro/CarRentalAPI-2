using System;

namespace CarRentalCore.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime DateFrom { get; set; }
   
        public DateTime DateTo { get; set; }
      
        public int VehicleID { get; set; }

        public int CustomerID { get; set; }

        public double Price { get; set; }
        public VehicleDTO Vehicle { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
