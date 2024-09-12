using AutoMapper;
using Libreria_backend.Context;
using Libreria_backend.DTO;
using Libreria_backend.Entidades;
using Libreria_backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria_backend.Servicios
{
    public class LibroService : ILibroService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public LibroService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CrearLibro(LibroDTO libroDTO)
        {
            var autor = await _dbContext.Autores.FirstOrDefaultAsync(x => x.Rut == libroDTO.AutorRut);
            if (autor == null)
            {
                throw new Exception($"El autor no está registrado");
            }

            var cantidadLibros = await _dbContext.Libros.CountAsync(x => x.Autor_id == autor.Autor_id);

            if (cantidadLibros >= 10)
            {
                throw new Exception($"No es posible registrar el libro, se alcanzó el máximo permitido");
            }

            var libro = _mapper.Map<Libro>(libroDTO);
            libro.Autor_id = autor.Autor_id;
            _dbContext.Libros.Add(libro);
            await _dbContext.SaveChangesAsync();
        }
    }
}
