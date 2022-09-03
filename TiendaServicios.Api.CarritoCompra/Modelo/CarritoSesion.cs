using System;
using System.Collections.Generic;

namespace TiendaServicios.Api.CarritoCompra.Modelo
{
    public class CarritoSesion
    {
        public int carritoSesionId { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public ICollection<CarritoSesionDetalle> listaDetalle { get; set; }
    }
}

