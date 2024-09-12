using AutoMapper;
using Libreria_backend.DTO;
using Libreria_backend.Entidades;

namespace Libreria_backend.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AutorDTO, Autor>().ReverseMap();
            CreateMap<LibroDTO, Libro>().ReverseMap();
        }
    }
}
