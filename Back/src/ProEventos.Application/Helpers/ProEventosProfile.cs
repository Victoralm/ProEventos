using AutoMapper;
using ProEventos.Domain;
using ProEventos.Application.DTOs;

namespace ProEventos.Application.Helpers
{
    /// <summary>
    /// Responsible for the auto-mapping of the POCO classes into DTO classes
    /// and vice-versa
    /// </summary>
    public class ProEventosProfile : Profile
    {
        public ProEventosProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
        }
    }
}