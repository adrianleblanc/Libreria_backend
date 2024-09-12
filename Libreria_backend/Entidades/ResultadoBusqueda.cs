namespace Libreria_backend.Entidades
{
    public class ResultadoBusqueda
    {
        public IEnumerable<Autor> Autores { get; set; }
        public IEnumerable<Libro> Libros { get; set; }
    }
}
