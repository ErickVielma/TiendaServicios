using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.Api.Autor.Migrations
{
    public partial class MigracionPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorLibro",
                columns: table => new
                {
                    autorLibroId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: true),
                    autorLibroGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => x.autorLibroId);
                });

            migrationBuilder.CreateTable(
                name: "GradoAcademico",
                columns: table => new
                {
                    gradoAcademicoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(nullable: true),
                    centroAcademico = table.Column<string>(nullable: true),
                    fechaGradoAcademico = table.Column<DateTime>(nullable: true),
                    autorLibroId = table.Column<int>(nullable: false),
                    gradoAcademicoGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoAcademico", x => x.gradoAcademicoId);
                    table.ForeignKey(
                        name: "FK_GradoAcademico_AutorLibro_autorLibroId",
                        column: x => x.autorLibroId,
                        principalTable: "AutorLibro",
                        principalColumn: "autorLibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradoAcademico_autorLibroId",
                table: "GradoAcademico",
                column: "autorLibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradoAcademico");

            migrationBuilder.DropTable(
                name: "AutorLibro");
        }
    }
}
