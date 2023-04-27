using HotelListing.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Application.DataAccess.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                 new Country { Id = 1, Name = "Nigeria", ShortName = "NGR" },
                new Country { Id = 2, Name = "England", ShortName = "ENG" },
                new Country { Id = 3, Name = "Ghana", ShortName = "GHN" }
                );
        }
    }
}
