using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using Microsoft.AspNetCore.Http;
using ProEventos.Application.DTOs;

namespace ProEventos.API.Controllers
{
    /*
    Notar q td controller precisa ter o sufixo "Controller" em seu nome:
    WeatherForecastController. Herdam de ControllerBase

    Definição da rota: [Route("[controller]")]
    */

    /// <summary>
    /// Responsible to receive the Lote objects HTTP requests to the Eventos objects
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        /// <summary>
        /// Used to make a reference to the class ProEventos.Application.EventoService
        /// </summary>
        private readonly IEventoService _eventoService;

        /// <summary>
        /// Receives a dependency injection of an object of type ProEventos.Application.EventoService
        /// </summary>
        /// <param name="eventoService">Object of type ProEventos.Application.EventoService</param>
        public EventoController(IEventoService eventoService)
        {
            this._eventoService = eventoService;
        }

        /// <summary>
        /// Handles the Eventos get request using
        /// ProEventos.Application.EventoService.GetAllEventosAsync
        /// </summary>
        /// <returns>An Ok() response object (json) that contains an array of
        /// all Eventos records</returns>
        [HttpGet] // Rota Get simples, sem parâmetros
        public async Task<IActionResult> Get() // IActionResult permite retornar o status code da request HTTP
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                // Retorna 204: Operação efetuada com sucesso mas sem conteúdo
                // Ref: https://www.w3schools.com/tags/ref_httpmessages.asp
                if(eventos == null) return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar eventos... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/

        /// <summary>
        /// Handles the Eventos get request by <paramref name="id"/>, using
        /// ProEventos.Application.EventoService.GetEventoByIdAsync
        /// </summary>
        /// <param name="id">The ID of the Eventos record to be returned</param>
        /// <returns>An Ok() response object (json) that contains a single record from the Eventos table</returns>
        [HttpGet("{id}")] // Rota Get, com parâmetro id
        public async Task<ActionResult<Evento>> Get(int id) // IActionResult permite retornar o status code da request HTTP
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if(evento == null) return NotFound("Nenhum evento encontrado");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar evento com o id especificado... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/2

        /// <summary>
        /// Handles the Eventos get request by <paramref name="tema"/>, using
        /// ProEventos.Application.EventoService.GetAllEventosByTemaAsync
        /// </summary>
        /// <param name="tema">Term to be searched on the Tema column of the Eventos records</param>
        /// <returns>An Ok() response object (json) that contains an array of
        /// all records from the Eventos table that contains the searched value
        /// in the Tema column</returns>
        [HttpGet("{tema}/tema")] // Rota Get, com parâmetro tema
        public async Task<IActionResult> Get(string tema) // IActionResult permite retornar o status code da request HTTP
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if(eventos == null) return NotFound("Nenhum evento por tema encontrado");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar eventos... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/tema

        /// <summary>
        /// Handles the Eventos post request using
        /// ProEventos.Application.EventoService.AddEventos
        /// </summary>
        /// <param name="model">An object of type ProEventos.Application.DTOs.EventoDto to be stored</param>
        /// <returns>An Ok() response object (json) that contains the Id of the
        /// new record stored on the Eventos table</returns>
        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                // Retorna 204: Operação efetuada com sucesso mas sem conteúdo
                // Ref: https://www.w3schools.com/tags/ref_httpmessages.asp
                if(evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar adicionar evento... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/

        /// <summary>
        /// Handles the Eventos put request by <paramref name="id"/>, using
        /// ProEventos.Application.EventoService.UpdateEvento
        /// </summary>
        /// <param name="id">The Id of the Eventos record that should be updated</param>
        /// <param name="model">The content of the Eventos record that should be
        /// updated</param>
        /// <returns>An Ok() response object (json) that contains the Id of the updated record</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                // Retorna 204: Operação efetuada com sucesso mas sem conteúdo
                // Ref: https://www.w3schools.com/tags/ref_httpmessages.asp
                if(evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar atualizar evento... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/31

        /// <summary>
        /// Handles the Eventos delete request by <paramref name="id"/>, using
        /// ProEventos.Application.EventoService.GetEventoByIdAsync to verify if
        /// the record actually exists, and
        /// ProEventos.Application.EventoService.DeleteEvento to delete it
        /// </summary>
        /// <param name="id">The Id of the Eventos record that should be
        /// deleted</param>
        /// <returns>An Ok() response object (json) that contains a message</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                // Retorna 204: Operação efetuada com sucesso mas sem conteúdo
                // Ref: https://www.w3schools.com/tags/ref_httpmessages.asp
                if(evento == null) return NoContent();

                return await _eventoService.DeleteEvento(id) ?
                                Ok(new {message = "Evento deletado."}) :
                                throw new Exception("Ocorreu um problema específico ao tentar deletar o evento");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar deletar evento... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/31
    }
}
