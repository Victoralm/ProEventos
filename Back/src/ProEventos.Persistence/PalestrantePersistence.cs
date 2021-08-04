using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    /// <summary>
    /// Responsible for actually dealing with the records on the DB table Palestrantes
    /// </summary>
    public class PalestrantePersistence : IPalestrantePersistence
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
        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;
        }

        #region Palestrantes
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                            .Include(p => p.RedesSociais);

            if(includeEventos)
                query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                            .Include(p => p.RedesSociais);

            if(includeEventos)
                query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                            .Include(p => p.RedesSociais);

            if(includeEventos)
                query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                    .Where(p => p.Id == palestranteId);

            // Using "FirstOrDefaultAsync" since it will return a single register
            return await query.FirstOrDefaultAsync();
        }
        #endregion

    }
}