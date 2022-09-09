using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Gateway.LibroRemote
{
    public class LibroModeloRemote
    {
        public Guid? libreriaMaterialId { get; set; }
        public string titulo { get; set; }
        public DateTime? fechaPublicacion { get; set; }
        public Guid? autorLibro { get; set; }

        public AutorModeloRemote autor { get; set }
    }
}
