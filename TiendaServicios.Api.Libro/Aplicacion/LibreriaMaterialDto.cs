using System;
namespace TiendaServicios.Api.Libro.Aplicacion
{
	public class LibreriaMaterialDto
	{
		public Guid? libreriaMaterialId { get; set; }
		public string titulo { get; set; }
		public DateTime? fechaPublicacion { get; set; }
		public Guid? autorLibro { get; set; }
	}
}

