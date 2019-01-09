using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    //Data transfer Object
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 64 characters.")]
        public string Password { get; set; }
    }
}