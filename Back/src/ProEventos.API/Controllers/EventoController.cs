using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

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
        /**
         * Old example
        public IEnumerable<Evento> evento = new Evento[]
            {
                new Evento()
                {
                    EventoId = 1,
                    Tema = "Angular 11 e .Net 5",
                    Local = "Rio de Janeiro",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemURL = "foto.png"
                },
                new Evento()
                {
                    EventoId = 2,
                    Tema = "Angular e suas novidades",
                    Local = "Botafogo",
                    Lote = "2º Lote",
                    QtdPessoas = 150,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                    ImagemURL = "foto1.png"
                }
            };
            */

        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet] // Rota Get simples, sem parâmetros
        public IEnumerable<Evento> Get()
        {
            // IEnumerable espera q o retorno seja um array
            return _context.Eventos;
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
        public Evento Get(int id)
        {
            // IEnumerable espera q o retorno seja um array
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/2

        [HttpPost]
        public string Post()
        {
            return "Post exemplo";
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Put exemplo id = {id}";
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/31

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Delete exemplo id = {id}";
        }
        // URL para testar no Postman: https://localhost:5001/api/Evento/31
    }
}
