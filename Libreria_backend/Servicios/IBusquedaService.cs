using Libreria_backend.Entidades;

namespace Libreria_backend.Servicios
{
    public interface IBusquedaService
    {
        Task<IEnumerable<Autor>> BuscarAutores(string rut, string authorName);
        Task<IEnumerable<Libro>> BuscarLibros(string keywords, string title, int? year, IEnumerable<Autor> autores);
    }
}
