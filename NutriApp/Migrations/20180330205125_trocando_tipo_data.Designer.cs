﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NutriApp.Data;
using System;

namespace NutriApp.Migrations
{
    [DbContext(typeof(NutriAppContext))]
    [Migration("20180330205125_trocando_tipo_data")]
    partial class trocando_tipo_data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NutriApp.Model.Endereco", b =>
                {
                    b.Property<int?>("idPaciente");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("localidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.HasKey("idPaciente");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("NutriApp.Model.Paciente", b =>
                {
                    b.Property<int>("idPaciente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("celular")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("datanascimento")
                        .HasColumnType("date");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("sexo")
                        .HasColumnType("char(1)");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("telefone")
                        .HasColumnType("varchar(10)");

                    b.HasKey("idPaciente");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("NutriApp.Model.Endereco", b =>
                {
                    b.HasOne("NutriApp.Model.Paciente", "Paciente")
                        .WithOne("Endereco")
                        .HasForeignKey("NutriApp.Model.Endereco", "idPaciente")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
