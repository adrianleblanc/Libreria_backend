using Libreria_backend.DTO;
using Libreria_backend.Entidades;

namespace Libreria_backend.Interfaces
{
    public interface IAutorService
    {
        Task<Autor> BuscarAutorPorRut(string rut);
        Task CrearAutor(AutorDTO autor);
    }
}
