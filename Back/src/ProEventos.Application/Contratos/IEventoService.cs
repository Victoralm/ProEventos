using System.Threading.Tasks;
using ProEventos.Application.DTOs;

namespace ProEventos.Application.Contratos
{
    /// <summary>
    /// Intermediates the communications between the API and the Persistence
    /// layers for records on the Eventos table.
    /// </summary>
    public interface IEventoService
    {
        /// <summary>
        /// Uses
        /// ProEventos.Persistence.GeneralPersistence.SaveChangesAsync
        /// to generate a new Evento record
        /// Intermediates the communications between the API and the Persistence layers.
        /// </summary>
        /// <param name="model">An object of type
        /// ProEventos.Application.DTOs.EventoDto to be stored</param>
        /// <returns>The Id of the new record stored on the Eventos table</returns>
        Task<EventoDto> AddEventos(EventoDto model);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.GeneralPersistence.SaveChangesAsync
        /// to save a new Eventos record
        /// Intermediates the communications between the API and the Persistence layers.
        /// </summary>
        /// <param name="eventoId">The Id of the Eventos record that should be updated</param>
        /// <param name="model">The content of the Eventos record that should be updated</param>
        /// <returns>The Id of the updated record</returns>
        Task<EventoDto> UpdateEvento(int eventoId, EventoDto model);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.GeneralPersistence.Delete<T>
        /// to delete existing Eventos records
        /// Intermediates the communications between the API and the Persistence layers.
        /// </summary>
        /// <param name="eventoId">The Id of the Eventos record that should be deleted</param>
        /// <returns>Returns a bool indicating if the procedure was successfully
        /// done</returns>
        Task<bool> DeleteEvento(int eventoId);

        /// <summary>
        /// Uses ProEventos.Persistence.GeneralPersistence.GetAllEventosAsync to
        /// get an array of all records on Eventos table
        /// Intermediates the communications between the API and the Persistence layers.
        /// </summary>
        /// <param name="includePalestrantes">Checks if should include the
        /// associated records on Palestrantes table. Default: false</param>
        /// <returns>Returns an array of all records on Eventos table</returns>
        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.EventoPersistence.GetAllEventosByTemaAsync
        /// to get an array of records on the Eventos table that contains the
        /// searched value in the Tema column
        /// Intermediates the communications between the API and the Persistence layers.
        /// </summary>
        /// <param name="tema">Term to be searched on the Tema column of the
        /// Eventos records</param>
        /// <param name="includePalestrantes">Checks if should include the
        /// associated records on Palestrantes table. Default: false</param>
        /// <returns>An array of all records on Eventos table that contains the
        /// searched value in the Tema column</returns>
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.EventoPersistence.GetEventoByIdAsync
        /// to get a single record on the Eventos table
        /// Intermediates the communications between the API and the Persistence
        /// layers.
        /// </summary>
        /// <param name="eventoId">Id of the record on Eventos table to be searched</param>
        /// <param name="includePalestrantes">Checks if should include the
        /// associated records on Palestrantes table. Default: false</param>
        /// <returns>A single record on the Eventos table</returns>
        Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}