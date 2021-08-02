namespace ProEventos.Application.DTOs
{
    public class RedeSocialDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; } // Será usado como chave extrangeira
        public EventoDto Evento { get; set; }
        public int? PalestranteId { get; set; } // Será usado como chave extrangeira
        public PalestranteDto Palestrante { get; set; }
    }
}