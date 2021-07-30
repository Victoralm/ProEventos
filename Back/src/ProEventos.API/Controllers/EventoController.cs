using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    /*
    Notar q td controller precisa ter o sufixo "Controller" em seu nome:
    WeatherForecastController. Herdam de ControllerBase

    Definição da rota: [Route("[controller]")]
    */
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            this._eventoService = eventoService;
        }

        [HttpGet] // Rota Get simples, sem parâmetros
        public async Task<IActionResult> Get() // IActionResult permite retornar o status code da request HTTP
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("Nenhum evento encontrado");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar eventos... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/

        /**
        [HttpGet("{id}")] // Rota Get, com parâmetro id
        // Get by id
        public IEnumerable<Evento> Get(int id)
        {
            // IEnumerable espera q o retorno seja um array
            return _context.Eventos.Where(evento => evento.EventoId == id);
        }
        */
        // URL para testar no Postman: https://localhost:5001/api/Evento/2

        [HttpGet("{id}")] // Rota Get, com parâmetro id
        // Get by id
        // public async Task<IActionResult> Get(int id) // IActionResult permite retornar o status code da request HTTP
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

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var eventos = await _eventoService.AddEventos(model);
                if(eventos == null) return BadRequest("Erro ao adicionar evento");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar adicionar evento... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var eventos = await _eventoService.UpdateEvento(id, model);
                if(eventos == null) return BadRequest("Erro ao adicionar evento");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar atualizar evento... Erro: {ex.Message}");
            }
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/31

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // if(await _eventoService.DeleteEvento(id))
                //     return Ok("Evento deletado.");
                // else
                //     return BadRequest("Evento não deletado");
                return await _eventoService.DeleteEvento(id) ?
                                Ok("Evento deletado.") :
                                BadRequest("Evento não deletado");
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
