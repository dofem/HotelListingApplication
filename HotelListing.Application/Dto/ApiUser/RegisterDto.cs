using System.ComponentModel.DataAnnotations;

namespace HotelListing.Application.Dto.ApiUser
{
    public class RegisterDto : LoginDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
