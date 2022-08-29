using System;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;

/**
 * Capa de contexto donde se origina la conexión a la base de datos
 * 
 */
namespace TiendaServicios.Api.Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options) {}
        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}