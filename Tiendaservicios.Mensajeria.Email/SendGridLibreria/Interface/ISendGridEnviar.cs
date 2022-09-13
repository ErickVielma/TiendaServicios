using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiendaservicios.Mensajeria.Email.SendGridLibreria.Modelo;

namespace Tiendaservicios.Mensajeria.Email.SendGridLibreria.Interface
{
    public interface ISendGridEnviar
    {
        Task<(bool resultado, string errorMensaje)> enviarEmail(SendGridData datos);
    }
}
