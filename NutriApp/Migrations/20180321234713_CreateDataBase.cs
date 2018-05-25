using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NutriApp.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    idPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    celular = table.Column<string>(type: "varchar(11)", nullable: true),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    datanascimento = table.Column<DateTime>(nullable: false),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    sexo = table.Column<string>(type: "char(1)", nullable: true),
                    sobrenome = table.Column<string>(type: "varchar(100)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.idPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    idPaciente = table.Column<int>(nullable: false),
                    bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    complemento = table.Column<string>(type: "varchar(100)", nullable: false),
                    localidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(255)", nullable: false),
                    numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    uf = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.idPaciente);
                    table.ForeignKey(
                        name: "FK_Endereco_Paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
