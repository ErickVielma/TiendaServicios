using System;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.Modelo;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibreriaMaterialDto>
        {
            public string libreriaMaterialId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibreriaMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _mapper = mapper;
                _contexto = contexto;
            }

            public async Task<LibreriaMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.LibreriaMaterial.Where(x => Convert.ToString(x.libreriaMaterialId) == request.libreriaMaterialId).FirstOrDefaultAsync();
                if (autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var autorDto = _mapper.Map<LibreriaMaterial, LibreriaMaterialDto>(autor);
                return autorDto;
            }
        }
    }
}

