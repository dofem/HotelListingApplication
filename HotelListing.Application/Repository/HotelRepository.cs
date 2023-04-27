using AutoMapper;
using HotelListing.Application.DataAccess.Data;
using HotelListing.Application.Interface;
using HotelListing.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Application.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context, IMapper mapper) : base(context , mapper)
        {
            
        }
    }
}
