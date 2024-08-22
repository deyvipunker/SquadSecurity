using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquadSecurity.Backend.Migrations
{
    /// <inheritdoc />
    public partial class addEntidadesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Excepciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exception = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Sustento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HabiliutadoresRelacionados = table.Column<int>(type: "int", nullable: false),
                    FechaAtencion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excepciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iniciativas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Aplicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Negocio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iniciativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevisionCabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSquad = table.Column<int>(type: "int", nullable: false),
                    CodigoIniciativa = table.Column<int>(type: "int", nullable: false),
                    CodigoAnalista = table.Column<int>(type: "int", nullable: false),
                    CodigoArquitecto = table.Column<int>(type: "int", nullable: false),
                    CodigoQuarter = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionCabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tribu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Negocio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoArquitecto = table.Column<int>(type: "int", nullable: false),
                    CodigoAnalista = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevisionDets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCabecera = table.Column<int>(type: "int", nullable: false),
                    CodigoIniciativa = table.Column<int>(type: "int", nullable: false),
                    CodigoHabilitador = table.Column<int>(type: "int", nullable: false),
                    CodigoSquad = table.Column<int>(type: "int", nullable: false),
                    Entregable = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CodigoEstadoCumplimiento = table.Column<int>(type: "int", nullable: false),
                    CodigoExcepcion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<int>(type: "int", nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RevisionCabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionDets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionDets_RevisionCabs_RevisionCabId",
                        column: x => x.RevisionCabId,
                        principalTable: "RevisionCabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SquadDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSquad = table.Column<int>(type: "int", nullable: false),
                    CodigoIntegrante = table.Column<int>(type: "int", nullable: false),
                    CodigoAsignacion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<int>(type: "int", nullable: true),
                    EstadoAuditoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaAuditoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAuditoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadDetalles_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_Dni",
                table: "Colaboradores",
                column: "Dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iniciativas_Nombre",
                table: "Iniciativas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RevisionCabs_CodigoIniciativa_CodigoSquad",
                table: "RevisionCabs",
                columns: new[] { "CodigoIniciativa", "CodigoSquad" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RevisionDets_RevisionCabId",
                table: "RevisionDets",
                column: "RevisionCabId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SquadDetalles_SquadId",
                table: "SquadDetalles",
                column: "SquadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Squads_Nombre",
                table: "Squads",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Excepciones");

            migrationBuilder.DropTable(
                name: "Iniciativas");

            migrationBuilder.DropTable(
                name: "RevisionDets");

            migrationBuilder.DropTable(
                name: "SquadDetalles");

            migrationBuilder.DropTable(
                name: "RevisionCabs");

            migrationBuilder.DropTable(
                name: "Squads");
        }
    }
}
