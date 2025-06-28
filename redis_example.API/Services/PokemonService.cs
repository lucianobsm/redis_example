using redis_example.API.Services.DTOs;
using redis_example.API.Services.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace redis_example.API.Services
{
    public class PokemonService(IHttpClientFactory factory, IConnectionMultiplexer muxer) : IPokemonService
    {
        private const string KEY_REDIS = "POKEMON";
        private readonly HttpClient _client = factory.CreateClient(KEY_REDIS);
        private readonly IDatabase _redis = muxer.GetDatabase();

        public async Task<List<Pokemon>> GetPokemonAsync()
        {
            string? json = await _redis.StringGetAsync(KEY_REDIS);

            if (string.IsNullOrEmpty(json))
            {
                var response = await _client.GetAsync($"pokemon?offset={0}&limit={10000}");
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();

                var setTask = _redis.StringSetAsync(KEY_REDIS, json);
                var expireTask = _redis.KeyExpireAsync(KEY_REDIS, TimeSpan.FromMinutes(5));

                await Task.WhenAll(setTask, expireTask);
            }

            var result = JsonSerializer.Deserialize<PokemonGetResponse>(json);
            return result.Results;
        }
    }
}
