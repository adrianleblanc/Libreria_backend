using Libreria_backend.Context;
using Libreria_backend.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Libreria_backend.Servicios
{
    public class BusquedaService : IBusquedaService
    {
        private readonly AppDbContext _dbContext;

        public BusquedaService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Libro>> BuscarLibros(string keywords, string title, int? year, IEnumerable<Autor> autores)
        {
            var query = _dbContext.Libros.AsQueryable();
            Boolean entra = false;
            if (!string.IsNullOrEmpty(keywords))
            {
                entra = true;
                query = query.Where(b => b.Titulo.Contains(keywords) || b.Genero.Contains(keywords));
            }
            if (!string.IsNullOrEmpty(title))
            {
                entra = true;
                query = query.Where(b => b.Titulo.Contains(title));
            }
            if (year.HasValue)
            {
                entra = true;
                query = query.Where(b => b.Anio == year.Value);
            }

            if (autores != null)
            {
                entra = true;
                foreach (var autor in autores)
                {
                    query = query.Where(b => b.Autor_id == autor.Autor_id);
                }
            }

            if (!entra) return Enumerable.Empty<Libro>();

            var resultados = await query.ToListAsync();
            return resultados;
        }

        public async Task<IEnumerable<Autor>> BuscarAutores(string rut, string authorName)
        {
            var query = _dbContext.Autores.AsQueryable();
            Boolean entra = false;

            if (!string.IsNullOrEmpty(rut))
            {
                entra = true;
                query = query.Where(a => a.Rut.Contains(rut));
            }
            if (!string.IsNullOrEmpty(authorName))
            {
                entra = true;
                query = query.Where(a => a.Nombre_completo.Contains(authorName));
            }

            if (!entra) return Enumerable.Empty<Autor>();

            return await query.ToListAsync();
        }
    }
}
