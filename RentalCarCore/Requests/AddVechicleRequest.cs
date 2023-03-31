using System.ComponentModel.DataAnnotations;

namespace CarRentalCore.Requests
{
    public class AddVechicleRequest
    {
        /// <summary>
        /// Model's Identifier 
        /// </summary>
        [Required]
        public int ModelID { get; set; }

        /// <summary>
        /// Vehicle's domain 
        /// </summary>
        [Required]
        [StringLength(15)]
        public string Domain { get; set; }
    }
}
