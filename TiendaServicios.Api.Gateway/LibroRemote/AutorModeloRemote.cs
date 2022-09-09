using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Gateway.LibroRemote
{
    public class AutorModeloRemote
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string autorLibroGuid { get; set; }
    }
}
