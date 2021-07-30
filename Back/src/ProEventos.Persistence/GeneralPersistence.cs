using System.Threading.Tasks;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class GeneralPersistence : IGeneralPersistence
    {
        private readonly ProEventosContext _context;

        // Injecting the context
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
            // If returns greater than zero
            return (await _context.SaveChangesAsync()) > 0;
        }
        #endregion

    }
}