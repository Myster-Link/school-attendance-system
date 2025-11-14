using System.Text.Json.Serialization;

namespace schoolattendance_api.Dtos.Auth
{
    public class AuthDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
