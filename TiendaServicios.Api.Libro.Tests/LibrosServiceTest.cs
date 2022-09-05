using System;
using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;
using Xunit;
namespace TiendaServicios.Api.Libro.Tests
{
    public class LibrosServiceTest
    {
        private IEnumerable<LibreriaMaterial> obtenerDatosPrueba()
        {
            A.Configure<LibreriaMaterial>()
                .Fill(x => x.titulo).AsArticleTitle()
                .Fill(x => x.libreriaMaterialId, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<LibreriaMaterial>(30);
            lista[0].libreriaMaterialId = Guid.Empty;

            return lista;
        }

        private Mock<ContextoLibreria> crearContexto()
        {
            var datosPrueba = obtenerDatosPrueba().AsQueryable();

            // Configuración de dbSet - Entidad de datos de prueba
            var dbSet = new Mock<DbSet<LibreriaMaterial>>();
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Provider).Returns(datosPrueba.Provider);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Expression).Returns(datosPrueba.Expression);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.ElementType).Returns(datosPrueba.ElementType);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.GetEnumerator()).Returns(datosPrueba.GetEnumerator());

            dbSet.As<IAsyncEnumerable<LibreriaMaterial>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<LibreriaMaterial>(datosPrueba.GetEnumerator()));

            var contexto = new Mock<ContextoLibreria>();
            contexto.Setup(x => x.LibreriaMaterial).Returns(dbSet.Object);
            return contexto;
        }

        [Fact]
        public async void getLibros()
        {
            System.Diagnostics.Debugger.Launch();
            // que método dentro de mi ms libro se encarga de la consulta de libros a bd

            //1. Emular a la instancia de EntityFrameworkCore - ContextoLibrería
            // Para emular las acciones y eventos de un objeto en un ambiente de UnitTest,
            // se utilizan objetos de tipo Mock
            var mockContexto = crearContexto();
             
            // 2. Emular el mapping IMapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            // 3. Instanciar a la clase Manejador y pasarle de parametros los mocks creados
            Consulta.Manejador manejador = new Consulta.Manejador(mockContexto.Object, mapper);

            Consulta.Ejecuta request = new Consulta.Ejecuta();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());

        }
    }
}

