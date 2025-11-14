using System.Text.Json.Serialization;

namespace schoolattendance_api.Dtos.User
{
    public class UserInsertDto
    {
        [JsonPropertyName("identification")]
        public string Identification { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }
    }
}
