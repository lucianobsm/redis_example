using Microsoft.AspNetCore.Mvc;
using redis_example.API.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace redis_example.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController(IPokemonService service) : ControllerBase
    {
        private readonly IPokemonService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetPokemonAsync());
        }
    }
}
