using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    /// <summary>
    /// CRUD(ish)
    /// </summary>
    public interface IProEventosPersistence
    {
        #region Itens Gerais
        /// <summary>
        /// Method Add as a generic type, with a generic parameter, where this type is a class
        /// </summary>
        /// <typeparam name="T">Generic type entity</typeparam>
        void Add<T>(T entity) where T: class;

        /// <summary>
        /// Method Update as a generic type, with a generic parameter, where this type is a class
        /// </summary>
        /// <typeparam name="T">Generic type entity</typeparam>
        void Update<T>(T entity) where T: class;

        /// <summary>
        /// Method Delete as a generic type, with a generic parameter, where this type is a class
        /// </summary>
        /// <typeparam name="T">Generic type entity</typeparam>
        void Delete<T>(T entity) where T: class;

        /// <summary>
        /// Method DeleteRange as a generic type, with a generic parameter, where this type is a class
        /// </summary>
        /// <typeparam name="T">Generic type entity</typeparam>
        void DeleteRange<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();
        #endregion

        #region Eventos
        /// <summary>
        /// Asynchronous get an array of all Eventos by tema
        /// </summary>
        /// <param name="tema">The Evento theme</param>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns></returns>
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);

        /// <summary>
        /// Asynchronous get an array of all Eventos
        /// </summary>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns></returns>
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);

        /// <summary>
        /// Asynchronous get an Evento by Id
        /// </summary>
        /// <param name="Id">The Id of the desired register</param>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns></returns>
        Task<Evento> GetEventosByIdAsync(int Id, bool includePalestrantes);
        #endregion

        #region Palestrantes
        /// <summary>
        /// Asynchronous get an array of all Palestrantes by name
        /// </summary>
        /// <param name="nome">The name of the speaker</param>
        /// <param name="includePalestrantes">Checks if wants to include Palestrantes</param>
        /// <returns></returns>
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);

        /// <summary>
        /// Asynchronous get an array of all Palestrantes
        /// </summary>
        /// <param name="includePalestrantes">Checks if wants to include Eventos</param>
        /// <returns></returns>
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);

        /// <summary>
        /// Asynchronous get a Palestrante by Id
        /// </summary>
        /// <param name="Id">The Id of the desired register</param>
        /// <param name="includeEventos">Checks if wants to include Eventos</param>
        /// <returns></returns>
        Task<Palestrante> GetPalestrantesByIdAsync(int PalestranteId, bool includeEventos);
        #endregion
    }
}