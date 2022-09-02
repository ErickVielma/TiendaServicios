using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

/**
 * Clase controller de la entidad de Autor
 * 
 * Author: Erick Eduardo Vielma Martínez
 * Since: Lunes, 29 de Agosto del 2022
 */
namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> getAutores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> getAutor(string id){
            return await _mediator.Send(new ConsultaFiltro.AutorUnico{ autorGuid = id});
        }
    }
}

