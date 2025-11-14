using schoolattendance_api.Dtos.User;
using System.Text.Json.Serialization;

namespace schoolattendance_api.Dtos.Auth
{
    public class AuthResponseDto
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("tokenExpiration")]
        public int? TokenExpiration { get; set; }

        [JsonPropertyName("userData")]
        public UserDto UserData { get; set; }
    }
}
