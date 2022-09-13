using System;
using System.Collections.Generic;
using System.Text;

namespace Tiendaservicios.Mensajeria.Email.SendGridLibreria.Modelo
{
    public class SendGridData
    {
        public string sendGridApiKey { get; set; }
        public string emailDestinatario { get; set; }
        public string nombreDestinatario { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
    }
}
