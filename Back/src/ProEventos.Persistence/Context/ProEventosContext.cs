using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Context
{
    public class ProEventosContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSocias { get; set; }

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