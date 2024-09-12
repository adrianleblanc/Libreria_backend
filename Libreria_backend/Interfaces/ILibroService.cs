using Libreria_backend.DTO;

namespace Libreria_backend.Interfaces
{
    public interface ILibroService
    {
        Task CrearLibro(LibroDTO libro);
    }
}
