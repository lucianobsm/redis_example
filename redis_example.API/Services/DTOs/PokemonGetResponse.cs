using System.Text.Json.Serialization;

namespace redis_example.API.Services.DTOs
{
    public class PokemonGetResponse
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
}
