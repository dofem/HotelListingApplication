using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Application.Dto.Hotel
{
    public class CreateHotelDto : BaseHotelDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
