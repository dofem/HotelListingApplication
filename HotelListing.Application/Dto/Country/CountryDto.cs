

using HotelListing.Application.Dto.Hotel;

namespace HotelListing.Application.Dto.Country
{
    public class CountryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }

}
