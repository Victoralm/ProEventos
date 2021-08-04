using System.Threading.Tasks;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    /// <summary>
    /// Makes a generic approach on dealing with the tables on the DB
    /// </summary>
    public class GeneralPersistence : IGeneralPersistence
    {
        /// <summary>
        /// Used to make a reference to the class ProEventos.Persistance.ProEventosContext
        /// </summary>
        private readonly ProEventosContext _context;

        /// <summary>
        /// Receives a dependency injection of an object of type
        /// ProEventos.Persistance.ProEventosContext
        /// </summary>
        /// <param name="context">An object of type ProEventos.Persistance.ProEventosContext</param>
        public GeneralPersistence(ProEventosContext context)
        {
            _context = context;
        }

        #region Itens Gerais
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // Returns true If greater than zero
            return (await _context.SaveChangesAsync()) > 0;
        }
        #endregion

    }
}