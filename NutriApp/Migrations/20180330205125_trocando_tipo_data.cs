using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NutriApp.Migrations
{
    public partial class trocando_tipo_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datanascimento",
                table: "Paciente",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datanascimento",
                table: "Paciente",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
