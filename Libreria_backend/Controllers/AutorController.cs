using Libreria_backend.DTO;
using Libreria_backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpPost]
        [Route("crearAutor")]
        public async Task<IActionResult> CrearAutor([FromBody] AutorDTO autorDTO)
        {
            if (autorDTO == null)
            {
                return BadRequest("Debe enviar un autor valido");
            }

            await _autorService.CrearAutor(autorDTO);
            return Ok(autorDTO);
        }
    }
}