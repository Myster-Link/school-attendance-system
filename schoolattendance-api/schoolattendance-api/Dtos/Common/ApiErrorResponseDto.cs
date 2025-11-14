using System.Text.Json.Serialization;

namespace schoolattendance_api.Dtos.Common
{
    public class ApiErrorResponseDto
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("errors")]
        public IEnumerable<string> Errors { get; set; }
    }
}