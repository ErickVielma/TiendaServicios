using System;
namespace TiendaServicios.Api.CarritoCompra.RemoteModel
{
    public class LibroRemote
    {
        public Guid? libreriaMaterialId { get; set; }
        public string titulo { get; set; }
        public DateTime? fechaPublicacion { get; set; }
        public Guid? autorLibro { get; set; }
    }
}

