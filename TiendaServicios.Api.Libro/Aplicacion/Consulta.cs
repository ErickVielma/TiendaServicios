using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Consulta
    {
        public class ListaLibro : IRequest<List<LibreriaMaterialDto>> { }

        public class Manejador : IRequestHandler<ListaLibro, List<LibreriaMaterialDto>>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _mapper = mapper;
                _contexto = contexto;
            }

            public async Task<List<LibreriaMaterialDto>> Handle(ListaLibro request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.LibreriaMaterial.ToListAsync();
                var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibreriaMaterialDto>>(libros);
                return librosDto;
            }
        }
    }
}