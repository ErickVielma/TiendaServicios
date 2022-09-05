using System;

/**
 * Entidad de GradoAcademico de la base de datos
 * 
 * Author: Erick Eduardo Vielma Martínez
 * Since: Lunes, 29 de Agosto del 2022
 */
namespace TiendaServicios.Api.Autor.Modelo
{
    public class GradoAcademico
    {
        public int gradoAcademicoId { get; set; }
        public string nombre { get; set; }
        public string centroAcademico { get; set; }
        public DateTime? fechaGradoAcademico { get; set; }
        public int autorLibroId { get; set; }
        public AutorLibro autorLibro { get; set; }
        public string gradoAcademicoGuid { get; set; }
    }
}

