using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiendaservicios.Mensajeria.Email.SendGridLibreria.Interface;
using Tiendaservicios.Mensajeria.Email.SendGridLibreria.Modelo;

namespace Tiendaservicios.Mensajeria.Email.SendGridLibreria.Implement
{
    public class SendGridEnviar : ISendGridEnviar
    {
        public async Task<(bool resultado, string errorMensaje)> enviarEmail(SendGridData datos)
        {
            try
            {
                var sendGridCliente = new SendGridClient(datos.sendGridApiKey);
                var destinatario = new EmailAddress(datos.emailDestinatario, datos.nombreDestinatario);
                var tituloEmail = datos.titulo;
                var sender = new EmailAddress("erickvielmadev@gmail.com", "Erick Vielma");
                var contenidoMensaje = datos.contenido;

                var objMensaje = MailHelper.CreateSingleEmail(sender, destinatario, tituloEmail, contenidoMensaje, contenidoMensaje);
                await sendGridCliente.SendEmailAsync(objMensaje);
                return (true, null);
            } catch (Exception e)
            {
                return (false, e.Message);
            }
        }
    }
}
