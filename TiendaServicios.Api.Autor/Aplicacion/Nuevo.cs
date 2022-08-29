using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

/**
 * Creación de Capa aplicación que conecta la parte de los controllers y la conexión a base de datos
 * Capa en donde se desarrolla la logica
 * 
 * Author: Erick Eduardo Vielma Martínez
 * Since: Lunes, 29 de Agosto del 2022
 */
namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        /**
         * Modelo que recibe el controller para procesarlo
         */
        public class Ejecuta : IRequest
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public DateTime? fechaNacimiento { get; set; }
            public string autorLibroGuid { get; set; }
        }

        /**
         * Método que ejecuta validaciones de modelos que recibimos
         */
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.nombre).NotEmpty();
                RuleFor(X => X.apellido).NotEmpty();               
            }
        }

        /**
         * Método donde se realiza el proceso de la logica y se manda a guardar un autor
         */
        public class Manejador : IRequestHandler<Ejecuta>
        {
            /**
             * Persistencia del metodo
             */
            public readonly ContextoAutor _contexto;

            /**
             * Constructor donde se hace la persistencia de datos
             */
            public Manejador (ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLbro = new AutorLibro
                {
                    nombre = request.nombre,
                    apellido = request.apellido,
                    fechaNacimiento = request.fechaNacimiento,
                    autorLibroGuid = Convert.ToString(Guid.NewGuid())
                };
                _contexto.AutorLibro.Add(autorLbro);
                var valor = await _contexto.SaveChangesAsync();          

                if(valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo Insertar el Autor del libro.");                
             }
        }
    }
}

