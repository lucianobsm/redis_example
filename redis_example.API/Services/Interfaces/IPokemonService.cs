using redis_example.API.Services.DTOs;

namespace redis_example.API.Services.Interfaces
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetPokemonAsync();
    }
}
