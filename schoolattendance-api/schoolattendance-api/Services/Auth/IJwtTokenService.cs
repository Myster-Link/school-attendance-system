using schoolattendance_api.Dtos.User;

namespace schoolattendance_api.Services.Auth
{
    public interface IJwtTokenService
    {
        int timeHours { get; }
        string GenerateToken(UserDto authDto);
    }
}
