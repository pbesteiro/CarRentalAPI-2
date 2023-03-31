using System;

namespace CarRentalCore.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string IdCard { get; set; }
        public string FullName { get; set; }

        public string Direction { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}
