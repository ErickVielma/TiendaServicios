using System;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.Modelo;

/**
 * Clase que permite la creación de la logica del microservicio
 * 
 */
namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Nuevo
    {
        /**
         * Modelo que recibe el controller para procesarlo
         */
        public class Ejecuta : IRequest
        {
            public string titulo { get; set; }            
            public DateTime? fechaPublicacion { get; set; }
            public Guid? autorLibro { get; set; }
        }

        /**
         * Método que ejecuta validaciones de modelos que recibimos
         */
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.titulo).NotEmpty();
                RuleFor(x => x.fechaPublicacion).NotEmpty();
                RuleFor(x => x.autorLibro).NotEmpty();
            }
        }

        /**
         * Método donde se realiza el proceso de la logica y se manda a guardar un autor
         */
        public class Manejador : IRequestHandler<Ejecuta>
        {
            /**
             * Persistencia del método
             */
            public readonly ContextoLibreria _contexto;

            /**
             * Constructor donde se hace la persistencia de datos
             */
            public Manejador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    titulo = request.titulo,
                    fechaPublicacion = request.fechaPublicacion,
                    autorLibro = request.autorLibro
                };
                _contexto.LibreriaMaterial.Add(libro);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo Insertar el Libro.");
            }
        }
    }
}

