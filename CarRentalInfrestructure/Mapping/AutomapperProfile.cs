using AutoMapper;
using CarRentalCore.DTOs;
using CarRentalCore.Requests;
using RentalCarCore.Entities;
namespace CarRentalInfrestructure.Mapping
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<VehicleType, VehicleTypeDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
            CreateMap<VehicleBrand, VehicleBrandDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Rental, RentalDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, AddCustomerRequest>().ReverseMap();
            CreateMap<Rental, AddRentRequest>().ReverseMap();
            CreateMap<User, AddUserRequest>().ReverseMap();
        }
    }
}
