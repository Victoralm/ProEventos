using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{

    /// <summary>
    /// Responsible for actually dealing with the records on the DB table Eventos
    /// </summary>
    public class EventoPersistence : IEventoPersistence
    {
        /// <summary>
        /// Used to make a reference to the class ProEventos.Persistance.ProEventosContext
        /// </summary>
        private readonly ProEventosContext _context;

        /// <summary>
        ///Receives a dependency injection of an object of type
        /// ProEventos.Persistance.ProEventosContext
        /// </summary>
        /// <param name="context">An object of type ProEventos.Persistance.ProEventosContext</param>
        public EventoPersistence(ProEventosContext context)
        {
            _context = context;
            // NoTracking para toda a classe
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region Eventos
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);

            if(includePalestrantes)
                query = query
                        .Include(e => e.PalestrantesEventos)
                        .ThenInclude(pe => pe.Palestrante);

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);

            if(includePalestrantes)
                query = query
                        .Include(e => e.PalestrantesEventos)
                        .ThenInclude(pe => pe.Palestrante);

            query = query.AsNoTracking().OrderBy(e => e.Id)
                    .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);

            if(includePalestrantes)
                query = query
                        .Include(e => e.PalestrantesEventos)
                        .ThenInclude(pe => pe.Palestrante);

            query = query.AsNoTracking().OrderBy(e => e.Id)
                    .Where(e => e.Id == eventoId);

            // Using "FirstOrDefaultAsync" since it will return a single register
            return await query.FirstOrDefaultAsync();
        }
        #endregion

    }
}