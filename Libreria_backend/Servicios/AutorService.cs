using AutoMapper;
using Libreria_backend.Context;
using Libreria_backend.DTO;
using Libreria_backend.Entidades;
using Libreria_backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria_backend.Servicios
{
    public class AutorService : IAutorService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AutorService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Autor> BuscarAutorPorRut(string rut)
        {
            return await _dbContext.Autores.FirstOrDefaultAsync(x => x.Rut == rut);
        }

        public async Task CrearAutor(AutorDTO autorDTO)
        {
            var existe = await BuscarAutorPorRut(autorDTO.Rut);
            if (existe != null)
            {
                throw new Exception($"El autor con el rut {autorDTO.Rut} ya existe");
            }

            var autor = _mapper.Map<Autor>(autorDTO);
            _dbContext.Autores.Add(autor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
