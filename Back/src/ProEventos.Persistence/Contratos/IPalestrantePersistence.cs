using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    /// <summary>
    /// CRUD(ish)
    /// </summary>
    public interface IPalestrantePersistence
    {

        #region Palestrantes
        /// <summary>
        /// Asynchronous get an array of all Palestrantes
        /// </summary>
        /// <param name="includePalestrantes">Checks if wants to include Eventos</param>
        /// <returns>An array of all records from Palestrantes table</returns>
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);

        /// <summary>
        /// Asynchronous get an array of all Palestrantes by name
        /// </summary>
        /// <param name="nome">The name of the speaker</param>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns>An array of records from Palestrantes table that contains
        /// the searched term in its name</returns>
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);

        /// <summary>
        /// Asynchronous get a Palestrante by Id
        /// </summary>
        /// <param name="Id">The Id of the desired register</param>
        /// <param name="includeEventos">Checks if wants to include Eventos</param>
        /// <returns>A single record from the Palestrantes table</returns>
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
        #endregion

    }
}