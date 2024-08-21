using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquadSecurity.Backend.Migrations
{
    /// <inheritdoc />
    public partial class addhabitadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilitadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    CodigoDimension = table.Column<int>(type: "int", nullable: false),
                    CodigoDominio = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoCriterio = table.Column<int>(type: "int", nullable: false),
                    CodigoLineamiento = table.Column<int>(type: "int", nullable: false),
                    CodigoImprescindible = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CodigoTipoSolucion = table.Column<int>(type: "int", nullable: false),
                    CodigoResponsable = table.Column<int>(type: "int", nullable: false),
                    DescripcionActividad = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CodigoAmbienteCapturaE = table.Column<int>(type: "int", nullable: false),
                    CodigoEtapaCaptura = table.Column<int>(type: "int", nullable: true),
                    CodigoEstadoCumplimiento = table.Column<int>(type: "int", nullable: false),
                    IdExcepcion = table.Column<int>(type: "int", nullable: true),
                    CodigoPlanAccion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilitadores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habilitadores_Codigo_Titulo",
                table: "Habilitadores",
                columns: new[] { "Codigo", "Titulo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habilitadores");
        }
    }
}
