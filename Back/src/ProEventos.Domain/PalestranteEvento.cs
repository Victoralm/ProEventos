namespace ProEventos.Domain
{
    /// <summary>
    /// Association class, N to N, between the tables Palestrantes e Eventos
    /// </summary>
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}