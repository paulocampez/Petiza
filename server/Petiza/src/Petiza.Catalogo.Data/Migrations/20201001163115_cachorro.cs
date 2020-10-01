using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petiza.Catalogo.Data.Migrations
{
    public partial class cachorro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Codigo", "Nome" },
                values: new object[] { new Guid("4ee35607-2d8d-4e45-a21d-167ff918ee74"), 1, "Cachorro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: new Guid("4ee35607-2d8d-4e45-a21d-167ff918ee74"));
        }
    }
}
