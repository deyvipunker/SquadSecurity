using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquadSecurity.Backend.Migrations
{
    /// <inheritdoc />
    public partial class tablaPrametros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_Nombre_Valor_Abreviatura",
                table: "Parametros",
                columns: new[] { "Nombre", "Valor", "Abreviatura" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametros");
        }
    }
}
