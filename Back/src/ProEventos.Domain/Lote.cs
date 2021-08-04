using System;
namespace ProEventos.Domain
{

    /// <summary>
    /// POCO class representing the DB table Lotes
    /// </summary>
    public class Lote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; } // Será usado como chave extrangeira
        public Evento Evento { get; set; }
    }
}