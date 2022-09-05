using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaServicios.Api.Libro.Migrations
{
    public partial class Migracioninicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibreriaMaterial",
                columns: table => new
                {
                    libreriaMaterialId = table.Column<Guid>(nullable: false),
                    titulo = table.Column<string>(nullable: true),
                    fechaPublicacion = table.Column<DateTime>(nullable: true),
                    autorLibro = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibreriaMaterial", x => x.libreriaMaterialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibreriaMaterial");
        }
    }
}
