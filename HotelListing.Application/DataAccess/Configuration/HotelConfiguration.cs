using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HotelListing.Domain.Model;

namespace HotelListing.Application.DataAccess.Configuration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, Name = "Royal Valley", Address = "Rivervill County", CountryId = 2, Rating = 4.7 },
                new Hotel { Id = 2, Name = "Eko Hotel and Suites", Address = " Victoria Island", CountryId = 1, Rating = 5.0 },
                new Hotel { Id = 3, Name = "Golden Valley Paradise", Address = "Kumasi Estate Layout", CountryId = 3, Rating = 3.7 }
                );
        }
    }
}
