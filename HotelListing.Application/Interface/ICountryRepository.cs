

using HotelListing.Domain.Model;

namespace HotelListing.Application.Interface
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int? id);
    }
}
