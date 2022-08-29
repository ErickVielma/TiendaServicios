using System;
using System.Collections.Generic;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class AutorDto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string autorLibroGuid { get; set; }
    }
}

