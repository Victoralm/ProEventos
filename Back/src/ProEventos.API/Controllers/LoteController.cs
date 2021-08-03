using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
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
    /// Responsible to receive the Lote objects HTTP requests to the Lote objects
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LoteController : ControllerBase
    {
        /// <summary>
        /// Used to make a reference to the class ProEventos.Application.LoteService
        /// </summary>
        private readonly ILoteService _loteService;

        /// <summary>
        /// Receives a dependency injection of an object of type ProEventos.Application.LoteService
        /// </summary>
        /// <param name="LoteService">Object of type ProEventos.Application.LoteService</param>
        public LoteController(ILoteService LoteService)
        {
            this._loteService = LoteService;
        }

        /// <summary>
        /// Handles the Lote get request by <paramref name="eventoId"/>, using
        /// ProEventos.Application.LoteService.GetLotesByEventoIdAsync
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <returns>An Ok() response object (json) that contains an array of Lote records</returns>
        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId) // IActionResult permite retornar o status code da request HTTP
        {
            try
            {
                var lotes = await _loteService.GetLotesByEventoIdAsync(eventoId);
                // Retorna 204: Operação efetuada com sucesso mas sem conteúdo
                // Ref: https://www.w3schools.com/tags/ref_httpmessages.asp
                if(lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar Lotes... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Lote/3


        /// <summary>
        /// Handles the Lote get request by <paramref name="eventoId"/>, using
        /// ProEventos.Application.LoteService.SaveLotes
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <param name="models">An array of objects of type ProEventos.Application.DTOs.LoteDto</param>
        /// <returns>An Ok() response object (json) that contains an array of Lote records</returns>
        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _loteService.SaveLotes(eventoId, models);
                // Retorna 204: Operação efetuada com sucesso mas sem conteúdo
                // Ref: https://www.w3schools.com/tags/ref_httpmessages.asp
                if(lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar salvar Lote(s)... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Lote/3

        /// <summary>
        /// Handles the Lote delete request by <paramref name="eventoId"/> and
        /// <paramref name="loteId"/>, by using
        /// ProEventos.Application.LoteService.GetLoteByEventoIdAsync
        /// to check if the Lote record exists and then delete it using
        /// ProEventos.Application.LoteService.DeleteLote
        /// </summary>
        /// <param name="eventoId">The Evento ID with which the records of the Lote
        /// array should be associated with it</param>
        /// <param name="loteId">The ID of the desired Lote</param>
        /// <returns>An Ok() response object (json) that contains a message or
        /// throw an exception if the operation fails</returns>
        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteService.GetLoteByEventoIdAsync(eventoId, loteId);
                // Retorna 204: Operação efetuada com sucesso mas sem conteúdo
                // Ref: https://www.w3schools.com/tags/ref_httpmessages.asp
                if(lote == null) return NoContent();

                return await _loteService.DeleteLote(lote.EventoId, lote.Id) ?
                                Ok(new {message = "Lote deletado."}) :
                                throw new Exception("Ocorreu um problema específico ao tentar deletar o Lote");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar deletar Lote... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Lote/3/18
    }
}
