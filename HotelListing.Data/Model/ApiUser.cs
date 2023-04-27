using Microsoft.AspNetCore.Identity;

namespace HotelListing.Domain.Model
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
