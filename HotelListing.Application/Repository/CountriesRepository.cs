using AutoMapper;
using HotelListing.Application.DataAccess.Data;
using HotelListing.Application.Interface;
using HotelListing.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Application.Repository
{
    public class CountriesRepository : GenericRepository<Country> , ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepository(ApplicationDbContext context,IMapper mapper) : base(context,mapper)
        {
            _context = context;
        }

        public async Task<Country> GetDetails(int? id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
        }

    }
}
