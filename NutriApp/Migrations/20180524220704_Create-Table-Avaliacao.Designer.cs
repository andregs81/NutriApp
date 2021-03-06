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
    [Migration("20180524220704_Create-Table-Avaliacao")]
    partial class CreateTableAvaliacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NutriApp.Model.Avaliacao", b =>
                {
                    b.Property<int>("idAvaliacao")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("batimentoCardiaco");

                    b.Property<decimal>("bioimpedancia");

                    b.Property<DateTime>("dataAvaliacao")
                        .HasColumnType("date");

                    b.Property<decimal>("estatura");

                    b.Property<int>("idPaciente");

                    b.Property<decimal>("iimc");

                    b.Property<decimal>("percRealizadoDieta");

                    b.Property<decimal>("percRealizadoTreino");

                    b.Property<decimal>("peso");

                    b.Property<string>("pressaoArterial");

                    b.HasKey("idAvaliacao");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("NutriApp.Model.DC", b =>
                {
                    b.Property<int?>("idAvaliacao");

                    b.Property<decimal>("abdominal");

                    b.Property<decimal>("escapular");

                    b.Property<decimal>("suprailiaca");

                    b.Property<decimal>("triceps");

                    b.HasKey("idAvaliacao");

                    b.ToTable("DC");
                });

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

                    b.Property<string>("email")
                        .HasColumnType("varchar(255)");

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

            modelBuilder.Entity("NutriApp.Model.Perimetros", b =>
                {
                    b.Property<int?>("idAvaliacao");

                    b.Property<decimal>("abdominal");

                    b.Property<decimal>("bracoDireito");

                    b.Property<decimal>("bracoEsquerdo");

                    b.Property<decimal>("cintura");

                    b.Property<decimal>("coxaDireita");

                    b.Property<decimal>("coxaEsquerda");

                    b.Property<decimal>("panturrilhaDireita");

                    b.Property<decimal>("panturrilhaEsquerda");

                    b.Property<decimal>("pulso");

                    b.Property<decimal>("quadril");

                    b.Property<decimal>("torax");

                    b.HasKey("idAvaliacao");

                    b.ToTable("Perimetros");
                });

            modelBuilder.Entity("NutriApp.Model.User", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessKey");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NutriApp.Model.DC", b =>
                {
                    b.HasOne("NutriApp.Model.Avaliacao", "Avaliacao")
                        .WithOne("DC")
                        .HasForeignKey("NutriApp.Model.DC", "idAvaliacao")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NutriApp.Model.Endereco", b =>
                {
                    b.HasOne("NutriApp.Model.Paciente", "Paciente")
                        .WithOne("Endereco")
                        .HasForeignKey("NutriApp.Model.Endereco", "idPaciente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NutriApp.Model.Perimetros", b =>
                {
                    b.HasOne("NutriApp.Model.Avaliacao", "Avaliacao")
                        .WithOne("Perimetros")
                        .HasForeignKey("NutriApp.Model.Perimetros", "idAvaliacao")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
