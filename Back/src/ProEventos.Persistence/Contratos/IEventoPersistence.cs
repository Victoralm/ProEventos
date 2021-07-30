using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    /// <summary>
    /// CRUD(ish)
    /// </summary>
    public interface IEventoPersistence
    {

        #region Eventos
        /// <summary>
        /// Asynchronous get an array of all Eventos
        /// </summary>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns></returns>
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);

        /// <summary>
        /// Asynchronous get an array of all Eventos by tema
        /// </summary>
        /// <param name="tema">The Evento theme</param>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns></returns>
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);

        /// <summary>
        /// Asynchronous get an Evento by Id
        /// </summary>
        /// <param name="EventoId">The Id of the desired register</param>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns></returns>
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
        #endregion

    }
}