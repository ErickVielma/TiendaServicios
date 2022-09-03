using System;
namespace TiendaServicios.Api.Libro.Modelo
{
    public class LibreriaMaterial
    {
        public Guid? libreriaMaterialId { get; set; }
        public string titulo { get; set; }
        public DateTime? fechaPublicacion { get; set; }
        public Guid? autorLibro { get; set; }
    }
}

