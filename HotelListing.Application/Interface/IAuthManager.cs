
using HotelListing.Application.Dto.ApiUser;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Application.Interface
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(RegisterDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
