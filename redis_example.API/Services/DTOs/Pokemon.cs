using System.Text.Json.Serialization;

namespace redis_example.API.Services.DTOs
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
