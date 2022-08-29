using System;
using System.Collections.Generic;

/**
 * Entidad de AutorLibro de la base de datos
 * 
 * Author: Erick Eduardo Vielma Martínez
 * Since: Lunes, 29 de Agosto del 2022
 */
namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorLibro
    {
        public int autorLibroId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public ICollection<GradoAcademico> listaGradoAcademico { get; set; }
        public string autorLibroGuid { get; set; }
    }
}

