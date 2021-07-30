using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        /// <summary>
        /// Responsável por intermediar, entre a API e a Persistencia, a geração
        /// de novos registros de Eventos
        /// </summary>
        /// <param name="model">Evento a ser gravado</param>
        /// <returns>Retorna o Id do novo registro armazenado em Eventos</returns>
        Task<Evento> AddEventos(Evento model);

        /// <summary>
        /// Responsável por intermediar, entre a API e a Persistencia, a
        /// atualização de registros pré-existentes em Eventos
        /// </summary>
        /// <param name="eventoId">Id do Evento a ser atualizado</param>
        /// <param name="model">Evento a ser atualizado</param>
        /// <returns>Retorna o Id do registro atualizado em Eventos</returns>
        Task<Evento> UpdateEvento(int eventoId, Evento model);

        /// <summary>
        /// Responsável pela remoção de registros pré-existentes em Eventos
        /// </summary>
        /// <param name="eventoId">Id do Evento a ser excluído</param>
        /// <returns>Retorna um bool indicando se a operação foi bem sucedida</returns>
        Task<bool> DeleteEvento(int eventoId);

        /// <summary>
        /// Responsável por intermediar, entre a API e a Persistencia, a busca
        /// por todos os registros em Eventos
        /// </summary>
        /// <param name="includePalestrantes">Parâmetro opcional para incluir os
        /// registros associados de Palestrantes. Default: false</param>
        /// <returns>Retorna um array contendo todos os registros em Eventos</returns>
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);

        /// <summary>
        /// Responsável por intermediar, entre a API e a Persistencia, a busca
        /// por todos os registros em Eventos que possuam o termo buscado na
        /// coluna Tema
        /// </summary>
        /// <param name="tema">Termo a ser buscado na coluna Tema</param>
        /// <param name="includePalestrantes">Parâmetro opcional para incluir os
        /// registros associados de Palestrantes. Default: false</param>
        /// <returns>Retorna um array contendo todos os registros em Eventos,
        /// onde a coluna Tema possua o termo buscado</returns>
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);

        /// <summary>
        /// Responsável por intermediar, entre a API e a Persistencia, a busca
        /// por um registro específico em Eventos. Filtrato pela Id do registro.
        /// </summary>
        /// <param name="eventoId">Id do Evento a ser localizado</param>
        /// <param name="includePalestrantes">Parâmetro opcional para incluir os
        /// registros associados de Palestrantes. Default: false</param>
        /// <returns></returns>
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}