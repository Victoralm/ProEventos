using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IEventoPersistence _eventoPersistence;

        public EventoService(IGeneralPersistence generalPersistence, IEventoPersistence eventoPersistence)
        {
            this._generalPersistence = generalPersistence;
            this._eventoPersistence = eventoPersistence;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _generalPersistence.Add<Evento>(model);
                if (await _generalPersistence.SaveChangesAsync())
                {
                    // Returns the Id of the new added record to the DB
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
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

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                _generalPersistence.Update(model);
                if (await _generalPersistence.SaveChangesAsync())
                {
                    // Returns the Id of the new added record to the DB
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
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

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetAllEventosAsync()
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                // Dealing with possible errors from
                // <EventoPersistence>.GetAllEventosByTemaAsync()
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if(eventos == null) return null;

                return eventos;
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