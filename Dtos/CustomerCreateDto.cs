using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    //Data transfer Object
    public class CustomerCreateDto
    {
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Name cannot exceed 50 characters.")]
		public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Name cannot exceed 50 characters.")]
		public string LastName { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Name cannot exceed 50 characters.")]
		public string CompanyName { get; set; }
		public int AddressID { get; set; }
        [StringLength(12, MinimumLength = 0, ErrorMessage = "Phone number cannot exceed 12 characters including hyphens.")]
        [RegularExpression(@"([0-9][0-9][0-9]-)?[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]", ErrorMessage = "Phone number must follow xxx-xxx-xxxx or xxx-xxxx format")]
		public string PhoneNumber { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Email cannot exceed 50 characters.")]
        [RegularExpression(@".*\@.*\..*", ErrorMessage = "Must follow standard email format")]
		public string Email { get; set; }
    }
}