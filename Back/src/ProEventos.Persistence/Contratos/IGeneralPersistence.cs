using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    /// <summary>
    /// CRUD(ish)
    /// </summary>
    public interface IGeneralPersistence
    {

        #region Itens Gerais
        /// <summary>
        /// Method Add as a generic type, with a generic typed parameter, where this type is a class
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
        void DeleteRange<T>(T[] entity) where T: class;

        Task<bool> SaveChangesAsync();
        #endregion

    }
}