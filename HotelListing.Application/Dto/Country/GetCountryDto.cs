using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Application.Dto.Country
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
 
}
