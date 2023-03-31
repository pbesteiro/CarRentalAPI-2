using System;

namespace CarRentalCore.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public DateTime DateCreation { get; set; }
        public UserDTO User { get; set; }
        public VehicleModelDTO Model { get; set; }
    }
}
