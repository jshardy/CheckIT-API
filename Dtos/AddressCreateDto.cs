using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    //Data transfer Object
    public class AddressCreateDto
    {
        [Required]
		public string Country { get; set; }
        [Required]
		public string State { get; set; }
        [Required]
		public string ZipCode {get; set; }
        [Required]
        public string City {get; set; }
        [Required]
		public string Street { get; set; }
		public string AptNum { get; set; }
        [Required]
		public bool DefaultAddress { get; set; }

    }
}