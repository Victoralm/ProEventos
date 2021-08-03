using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    /// <summary>
    /// CRUD(ish)
    /// </summary>
    public interface ILotePersistence
    {

        #region Eventos
        /// <summary>
        /// Asynchronous get an array of all Lotes relative to an Evento Id
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <returns>An array of all Lotes relative to the given Evento Id</returns>
        Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);

        /// <summary>
        /// Asynchronous get a single Lote associated with an Evento
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <param name="loteId">The ID of the desired Lote</param>
        /// <returns>A single Lote associated with the given Evento</returns>
        Task<Lote> GetLoteByEventoIdAsync(int eventoId, int loteId);
        #endregion

    }
}