using Libreria_backend.Entidades;
using Libreria_backend.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusquedaController : Controller
    {
        private readonly IBusquedaService _busquedaService;

        public BusquedaController(IBusquedaService busquedaService)
        {
            _busquedaService = busquedaService;
        }

        [HttpGet]
        [Route("buscar")]
        public async Task<IActionResult> Search(string keywords, string rut, string autor, string title, int? year)
        {
            var autores = await _busquedaService.BuscarAutores(rut, autor);
            var libros = await _busquedaService.BuscarLibros(keywords, title, year, autores);

            var result = new ResultadoBusqueda
            {
                Autores = autores,
                Libros = libros
            };

            return Json(result);
        }
    }
}
