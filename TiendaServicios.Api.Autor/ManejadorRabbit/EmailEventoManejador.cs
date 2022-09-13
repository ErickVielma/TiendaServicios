using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiendaservicios.Mensajeria.Email.SendGridLibreria.Interface;
using Tiendaservicios.Mensajeria.Email.SendGridLibreria.Modelo;
using TiendaServicios.RabbitMQ.Bus.BusRabbit;
using TiendaServicios.RabbitMQ.Bus.EventoQueue;

namespace TiendaServicios.Api.Autor.ManejadorRabbit
{
    public class EmailEventoManejador : IEventoManejador<EmailEventoQueue>
    {
        private readonly ILogger<EmailEventoManejador> _logger;
        private readonly ISendGridEnviar _sendGridEnviar;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public EmailEventoManejador(ILogger<EmailEventoManejador> logger, ISendGridEnviar sendGridEnviar, Microsoft.Extensions.Configuration.IConfiguration configuration) 
        {
            _logger = logger;
            _sendGridEnviar = sendGridEnviar;
            _configuration = configuration;
        }

        public EmailEventoManejador() { }

        public async Task Handle(EmailEventoQueue @event)
        {
            _logger.LogInformation(@event.titulo);

            var objDatos = new SendGridData();

            objDatos.contenido = @event.contenido;
            objDatos.emailDestinatario = @event.destinatario;
            objDatos.nombreDestinatario = @event.destinatario;
            objDatos.titulo = @event.titulo;
            objDatos.sendGridApiKey = _configuration["SendGrid:ApiKey"];

            var resultado = await _sendGridEnviar.enviarEmail(objDatos);

            if (resultado.resultado)
            {
                await Task.CompletedTask;
                return;
            }
        }
    }
}
