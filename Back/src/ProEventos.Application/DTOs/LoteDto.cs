namespace ProEventos.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object class
    /// Sets the standards to store records on the Lotes table
    /// </summary>
    public class LoteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; } // Será usado como chave extrangeira
        public EventoDto Evento { get; set; }
    }
}