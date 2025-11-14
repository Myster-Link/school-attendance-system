using schoolattendance_api.Dtos.Auth;
using schoolattendance_api.Dtos.User;

namespace schoolattendance_api.Services.Auth
{
    public interface IAuthService
    {
        public List<string> Errors { get; }
        Task<AuthResponseDto> Login(AuthDto authDto);
        Task<AuthResponseDto> Register(UserInsertDto userInsertDto);
    }
}
