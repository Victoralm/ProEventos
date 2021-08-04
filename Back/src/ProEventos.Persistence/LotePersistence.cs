using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    /// <summary>
    /// Responsible for actually dealing with the records on the DB table Lotes
    /// </summary>
    public class LotePersistence : ILotePersistence
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
        public LotePersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Lote> GetLoteByEventoIdAsync(int eventoId, int loteId)
        {
            IQueryable<Lote> query = _context.Lotes;
            query = query.AsNoTracking()
                        .Where(lote => lote.EventoId == eventoId && lote.Id == loteId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Lote[]> GetLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<Lote> query = _context.Lotes;
            query = query.AsNoTracking()
                        .Where(lote => lote.EventoId == eventoId);
            return await query.ToArrayAsync();
        }
    }
}