using Microsoft.AspNetCore.Mvc;
using WebApiNTT.Models;
using WebApiNTT.Services;

namespace WebApiNTT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : Controller
    {
        private readonly PersonaService _personaService;
        private readonly IConfiguration _configuration;
        public PersonasController(PersonaService personaService, IConfiguration configuration)
        {
            _personaService = personaService;
            _configuration = configuration;
        }

        [HttpGet("Generar")]
        public async Task<ActionResult<IEnumerable<Persona>>> GenerarPersonas([FromHeader(Name = "x-api-key")] string? apiKey)
        {
            var validKey = _configuration["ApiSettings:ApiKey"];

            if (string.IsNullOrEmpty(apiKey) || apiKey != validKey)
                return Unauthorized(new { message = "API Key incorrecta" });

            var personas = await _personaService.ObtenerPersonasAsync();

            return Ok(personas);
        }
    }
}
