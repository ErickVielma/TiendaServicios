using System;
namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDetalleDto
    {
        public Guid? libroId { get; set; }
        public string tituloLibro { get; set; }
        public string autorLibro { get; set; }
        public DateTime? fechaPublicacion { get; set; }
    }
}

