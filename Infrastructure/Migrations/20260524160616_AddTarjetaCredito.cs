using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTarjetaCredito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tarjetas_credito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreBanco = table.Column<string>(type: "text", nullable: false),
                    UltimoCuatroDigitos = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    NombreTitular = table.Column<string>(type: "text", nullable: false),
                    RedPago = table.Column<int>(type: "integer", nullable: false),
                    MesVencimiento = table.Column<int>(type: "integer", nullable: false),
                    AnioVencimiento = table.Column<int>(type: "integer", nullable: false),
                    LimiteCredito = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    DiaCorte = table.Column<int>(type: "integer", nullable: false),
                    ColorGradiente = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarjetas_credito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tarjetas_credito_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tarjetas_credito_UsuarioId",
                table: "tarjetas_credito",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tarjetas_credito");
        }
    }
}
