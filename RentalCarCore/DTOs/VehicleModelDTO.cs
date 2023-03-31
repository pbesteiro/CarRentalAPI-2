namespace CarRentalCore.DTOs
{
    public class VehicleModelDTO
    {
        public string Name { get; set; }

        public int Seats { get; set; }
    
        public bool Trunk { get; set; }
      
        public int Doors { get; set; }
  
        public int Airbags { get; set; }
 
        public int BrandID { get; set; }

        public int VehicleTypeID { get; set; }
      
        public VehicleBrandDTO Brand { get; set; }
   
        public VehicleTypeDTO VehicleType { get; set; }
    }
}
