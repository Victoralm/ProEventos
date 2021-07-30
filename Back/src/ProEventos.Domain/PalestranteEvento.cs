namespace ProEventos.Domain
{
    /// <summary>
    /// Classe de associação, N para N, entre as classes Palestrante e Evento
    /// </summary>
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}