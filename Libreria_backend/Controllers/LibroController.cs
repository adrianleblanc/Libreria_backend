using Libreria_backend.DTO;
using Libreria_backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost]
        [Route("crearLibro")]
        public async Task<IActionResult> CrearLibro([FromBody] LibroDTO libroDTO)
        {
            if (libroDTO == null)
            {
                return BadRequest("El objeto AutorDTO no puede ser nulo.");
            }

            await _libroService.CrearLibro(libroDTO);
            return Ok(libroDTO);
        }
    }
}
