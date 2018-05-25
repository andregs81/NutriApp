using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriApp.Data;
using NutriApp.Model;

namespace NutriApp.Data
{
    public class NutriAppContext : DbContext
    {
        public NutriAppContext(DbContextOptions<NutriAppContext> options)
            : base(options)
        {

        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Perimetros> Perimetros { get; set; }
        public DbSet<DC> DC { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluentApi
            #region Paciente
            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.idPaciente);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Endereco)
                .WithOne(e => e.Paciente)
                .HasForeignKey<Endereco>(e => e.idPaciente)
                .IsRequired(false);

            modelBuilder.Entity<Paciente>()
                .Property(p => p.nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Paciente>()
                            .Property(p => p.sobrenome)
                            .IsRequired()
                            .HasColumnType("varchar(100)");

            modelBuilder.Entity<Paciente>()
                            .Property(p => p.cpf)
                            .IsRequired()
                            .HasColumnType("varchar(11)");

            modelBuilder.Entity<Paciente>()
                            .Property(p => p.sexo)
                            .HasColumnType("char(1)");

            modelBuilder.Entity<Paciente>()
                            .Property(p => p.celular)
                            .HasColumnType("varchar(11)");

            modelBuilder.Entity<Paciente>()
                            .Property(p => p.telefone)
                            .HasColumnType("varchar(10)");

            modelBuilder.Entity<Paciente>()
                            .Property(p => p.datanascimento)
                            .HasColumnType("date");

            modelBuilder.Entity<Paciente>()
                            .Property(p => p.email)
                            .HasColumnType("varchar(255)");

            #endregion Paciente

            #region Endereco

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.idPaciente);


            modelBuilder.Entity<Endereco>()
                .Property(e => e.logradouro)
                .IsRequired()
                .HasColumnType("varchar(255)");

            modelBuilder.Entity<Endereco>()
                     .Property(e => e.localidade)
                     .IsRequired()
                     .HasColumnType("varchar(100)");

            modelBuilder.Entity<Endereco>()
                     .Property(e => e.uf)
                     .IsRequired()
                     .HasColumnType("char(2)");

            modelBuilder.Entity<Endereco>()
                     .Property(e => e.complemento)
                     .HasColumnType("varchar(100)");

            modelBuilder.Entity<Endereco>()
                     .Property(e => e.bairro)
                     .IsRequired()
                     .HasColumnType("varchar(100)");

            modelBuilder.Entity<Endereco>()
                                 .Property(e => e.cep)
                                 .IsRequired()
                                 .HasColumnType("varchar(10)");

            modelBuilder.Entity<Endereco>()
                                 .Property(e => e.numero)
                                 .IsRequired()
                                 .HasColumnType("varchar(10)");


            #endregion Endereco

            #region Avaliação

            modelBuilder.Entity<Avaliacao>()
                .HasKey(a => a.idAvaliacao);

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Perimetros)
                .WithOne(p => p.Avaliacao)
                .HasForeignKey<Perimetros>(p => p.idAvaliacao)
                .IsRequired(false);

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.DC)
                .WithOne(d => d.Avaliacao)
                .HasForeignKey<DC>(d => d.idAvaliacao)
                .IsRequired(false);

            modelBuilder.Entity<Avaliacao>()
                .Property(a => a.dataAvaliacao)
                .HasColumnType("date");



            #region Perimetros
            modelBuilder.Entity<Perimetros>()
                .HasKey(p => p.idAvaliacao);

            modelBuilder.Entity<Perimetros>()
                .HasKey(p => p.idAvaliacao);

            #endregion Perimetros


            #region DC
            modelBuilder.Entity<DC>()
                .HasKey(d => d.idAvaliacao);


            #endregion DC


            #endregion Avaliação

            #endregion FluentApi

        }
    }
}
