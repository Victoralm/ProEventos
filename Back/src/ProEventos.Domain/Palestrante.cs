using System.Collections.Generic;

namespace ProEventos.Domain
{

    /// <summary>
    /// POCO class representing the DB table Palestrantes
    /// </summary>
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}