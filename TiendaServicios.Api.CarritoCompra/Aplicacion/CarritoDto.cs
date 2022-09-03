using System;
using System.Collections.Generic;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDto
    {
        public int carritoId { get; set; }
        public DateTime? fechaCreacionSesion { get; set; }
        public List<CarritoDetalleDto> listaProductos { get; set; }
    }
}