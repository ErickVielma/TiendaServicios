// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Migrations
{
    [DbContext(typeof(ContextoAutor))]
    partial class ContextoAutorModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TiendaServicios.Api.Autor.Modelo.AutorLibro", b =>
                {
                    b.Property<int>("autorLibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("apellido")
                        .HasColumnType("text");

                    b.Property<string>("autorLibroGuid")
                        .HasColumnType("text");

                    b.Property<DateTime?>("fechaNacimiento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("autorLibroId");

                    b.ToTable("AutorLibro");
                });

            modelBuilder.Entity("TiendaServicios.Api.Autor.Modelo.GradoAcademico", b =>
                {
                    b.Property<int>("gradoAcademicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("autorLibroId")
                        .HasColumnType("integer");

                    b.Property<string>("centroAcademico")
                        .HasColumnType("text");

                    b.Property<DateTime?>("fechaGradoAcademico")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("gradoAcademicoGuid")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("gradoAcademicoId");

                    b.HasIndex("autorLibroId");

                    b.ToTable("GradoAcademico");
                });

            modelBuilder.Entity("TiendaServicios.Api.Autor.Modelo.GradoAcademico", b =>
                {
                    b.HasOne("TiendaServicios.Api.Autor.Modelo.AutorLibro", "autorLibro")
                        .WithMany("listaGradoAcademico")
                        .HasForeignKey("autorLibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
