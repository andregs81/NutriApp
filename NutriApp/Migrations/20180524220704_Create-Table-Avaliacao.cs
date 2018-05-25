using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NutriApp.Migrations
{
    public partial class CreateTableAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    idAvaliacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    batimentoCardiaco = table.Column<decimal>(nullable: false),
                    bioimpedancia = table.Column<decimal>(nullable: false),
                    dataAvaliacao = table.Column<DateTime>(type: "date", nullable: false),
                    estatura = table.Column<decimal>(nullable: false),
                    idPaciente = table.Column<int>(nullable: false),
                    iimc = table.Column<decimal>(nullable: false),
                    percRealizadoDieta = table.Column<decimal>(nullable: false),
                    percRealizadoTreino = table.Column<decimal>(nullable: false),
                    peso = table.Column<decimal>(nullable: false),
                    pressaoArterial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.idAvaliacao);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    AccessKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "DC",
                columns: table => new
                {
                    idAvaliacao = table.Column<int>(nullable: false),
                    abdominal = table.Column<decimal>(nullable: false),
                    escapular = table.Column<decimal>(nullable: false),
                    suprailiaca = table.Column<decimal>(nullable: false),
                    triceps = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DC", x => x.idAvaliacao);
                    table.ForeignKey(
                        name: "FK_DC_Avaliacao_idAvaliacao",
                        column: x => x.idAvaliacao,
                        principalTable: "Avaliacao",
                        principalColumn: "idAvaliacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perimetros",
                columns: table => new
                {
                    idAvaliacao = table.Column<int>(nullable: false),
                    abdominal = table.Column<decimal>(nullable: false),
                    bracoDireito = table.Column<decimal>(nullable: false),
                    bracoEsquerdo = table.Column<decimal>(nullable: false),
                    cintura = table.Column<decimal>(nullable: false),
                    coxaDireita = table.Column<decimal>(nullable: false),
                    coxaEsquerda = table.Column<decimal>(nullable: false),
                    panturrilhaDireita = table.Column<decimal>(nullable: false),
                    panturrilhaEsquerda = table.Column<decimal>(nullable: false),
                    pulso = table.Column<decimal>(nullable: false),
                    quadril = table.Column<decimal>(nullable: false),
                    torax = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perimetros", x => x.idAvaliacao);
                    table.ForeignKey(
                        name: "FK_Perimetros_Avaliacao_idAvaliacao",
                        column: x => x.idAvaliacao,
                        principalTable: "Avaliacao",
                        principalColumn: "idAvaliacao",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DC");

            migrationBuilder.DropTable(
                name: "Perimetros");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Avaliacao");
        }
    }
}
