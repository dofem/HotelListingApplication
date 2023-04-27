using System.ComponentModel.DataAnnotations;

namespace HotelListing.Application.Dto.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
