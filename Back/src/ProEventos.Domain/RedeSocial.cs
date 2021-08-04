
namespace ProEventos.Domain
{
    /// <summary>
    /// POCO class representing the DB table RedesSociais
    /// </summary>
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; } // Será usado como chave extrangeira
        public Evento Evento { get; set; }
        public int? PalestranteId { get; set; } // Será usado como chave extrangeira
        public Palestrante Palestrante { get; set; }
    }
}