using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.DTOs;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IEventoPersistence _eventoPersistence;
        private readonly IMapper _mapper;

        public EventoService(
            IGeneralPersistence generalPersistence,
            IEventoPersistence eventoPersistence,
            IMapper mapper
            )
        {
            this._generalPersistence = generalPersistence;
            this._eventoPersistence = eventoPersistence;
            this._mapper = mapper;
        }
        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                // mapeia o model de EventoDto para Evento e armazena na var evento
                var evento = _mapper.Map<Evento>(model);

                // Usando a var evento já mapeada para a classe Evento
                _generalPersistence.Add<Evento>(evento);

                if (await _generalPersistence.SaveChangesAsync())
                {
                    // the Id of the new added record to the DB
                    var eventoRetorno = await _eventoPersistence.GetEventoByIdAsync(evento.Id, false);
                    // Retorna a var retorno mapeada para EventoDto
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                // Returns null if can't save the record to the DB
                return null;
            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetEventosByIdAsync() and
                // <GeneralPersistence>.SaveChangesAsync()
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                // Mapeanto de um objeto para outro. Mapeia o model de EventoDto para Evento.
                _mapper.Map(model, evento);

                _generalPersistence.Update<Evento>(evento);

                if (await _generalPersistence.SaveChangesAsync())
                {
                    // the Id of the new added record to the DB
                    var eventoRetorno = await _eventoPersistence.GetEventoByIdAsync(evento.Id, false);
                    // Retorna a var retorno mapeada para EventoDto
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                // Returns null if can't save the record to the DB
                return null;

            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetEventosByIdAsync() and
                // <GeneralPersistence>.SaveChangesAsync()
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento especificado para ser deletado não foi encontrado...");

                _generalPersistence.Delete<Evento>(evento);
                return await _generalPersistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetEventosByIdAsync() and
                // <GeneralPersistence>.SaveChangesAsync()
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;

                // Execução do auto-mapeamento
                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetAllEventosAsync()
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null) return null;

                // Execução do auto-mapeamento
                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetAllEventosByTemaAsync()
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if(evento == null) return null;

                // Execução do auto-mapeamento
                var resultado = _mapper.Map<EventoDto>(evento);

                return resultado;
            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetEventoByIdAsync()
                throw new Exception(ex.Message);
            }
        }

    }
}