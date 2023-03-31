namespace CarRentalCore.Requests
{
    public class AddCustomerRequest
    {
        /// <summary>
        /// Card Id number 
        /// </summary>
        public string IdCard { get; set; }
        
        /// <summary>
        /// Name and LastName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Direction { get; set; }
  
    }
}
