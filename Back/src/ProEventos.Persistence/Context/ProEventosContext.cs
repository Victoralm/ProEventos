using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Context
{
    /// <summary>
    /// Responsible to convert the LINQ queries to DB queries.
    /// Stores all the DbSet objects for the tables of the DB
    /// </summary>
    public class ProEventosContext : DbContext
    {
        /// <summary>
        /// The DbSet for the Eventos table on the DB
        /// </summary>
        /// <value></value>
        public DbSet<Evento> Eventos { get; set; }

        /// <summary>
        /// The DbSet for the Lotes table on the DB
        /// </summary>
        /// <value></value>
        public DbSet<Lote> Lotes { get; set; }

        /// <summary>
        /// The DbSet for the Palestrantes table on the DB
        /// </summary>
        /// <value></value>
        public DbSet<Palestrante> Palestrantes { get; set; }

        /// <summary>
        /// The DbSet for the PalestrantesEventos table on the DB
        /// </summary>
        /// <value></value>
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        /// <summary>
        /// The DbSet for the RedesSocias table on the DB
        /// </summary>
        /// <value></value>
        public DbSet<RedeSocial> RedesSocias { get; set; }

        /// <summary>
        /// Receives a dependency injection of an object
        /// Microsoft.EntityFrameworkCore.DbContextOptions with type
        /// ProEventos.Persistence.ProEventosContext
        /// </summary>
        /// <param name="options">An
        /// Microsoft.EntityFrameworkCore.DbContextOptions object with type
        /// ProEventos.Persistence.ProEventosContext</param>
        /// <returns></returns>
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }

        /// <summary>
        /// Responsável por associar as classes Palestrantes e Eventos.
        /// Definindo que a classe PalestranteEvento é a classe de junção entre
        /// as duas classes supra citadas.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definindo os Id externos (Foreign Keys) que geram o
            // relacionamento entre as tabelas Eventos e Palestrantes
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            // Definindo o Cascade On Delete para que quando um Evento for
            // deletado, tenha as Redes Sociais associadas a ele também deletadas.
            modelBuilder.Entity<Evento>()
                        .HasMany(e => e.RedesSociais)
                        .WithOne(rs => rs.Evento)
                        .OnDelete(DeleteBehavior.Cascade);

            // Definindo o Cascade On Delete para que quando um Palestrante for
            // deletado, tenha as Redes Sociais associadas a ele também deletadas.
            modelBuilder.Entity<Palestrante>()
                        .HasMany(p => p.RedesSociais)
                        .WithOne(rs => rs.Palestrante)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}