using System.Threading.Tasks;
using ProEventos.Application.DTOs;

namespace ProEventos.Application.Contratos
{
    /// <summary>
    /// Intermediates the communications between the API and the Persistence
    /// layers for records on the Lotes table.
    /// </summary>
    public interface ILoteService
    {

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.GeneralPersistence.SaveChangesAsync
        /// to generate a new Lotes record
        /// </summary>
        /// <param name="eventoId">The Evento ID that the Lotes should associated with</param>
        /// <param name="model">An object of type
        /// ProEventos.Application.DTOs.LoteDto to be stored</param>
        /// <returns>The Id of the new record stored on the Lotes table</returns>
        Task AddLote(int eventoId, LoteDto model);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.GeneralPersistence.SaveChangesAsync
        /// to save new and existing Lote records
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <param name="models">An array of objects with type ProEventos.Application.DTOs.LoteDto</param>
        /// <returns>An array of object with type ProEventos.Application.DTOs.LoteDto</returns>
        Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] models);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.GeneralPersistence.Delete<T>
        /// to delete existing Lote records
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <param name="loteId">The ID of the desired Lote</param>
        /// <returns>A bool indicating if the operation was successfull</returns>
        Task<bool> DeleteLote(int eventoId, int loteId);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.LotePersistence.GetLotesByEventoIdAsync
        /// to get an array of all Lotes relative to the given Evento Id
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <returns>An array of all Lotes relative to the given Evento Id</returns>
        Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId);

        /// <summary>
        /// Uses
        /// ProEventos.Persistence.LotePersistence.GetLoteByEventoIdAsync
        /// to get a single Lote associated with the given Evento
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <param name="loteId">The ID of the desired Lote</param>
        /// <returns>A single Lote associated with the given Evento</returns>
        Task<LoteDto> GetLoteByEventoIdAsync(int eventoId, int loteId);
    }
}