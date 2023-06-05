﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minimal.Infraestrutura.Database;

#nullable disable

namespace minimal_api_matheusA.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20230602210517_adicionandoNovasEntidadesERelacionamentos")]
    partial class adicionandoNovasEntidadesERelacionamentos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Minimal.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AlunoId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Minimal.Models.Atividade", b =>
                {
                    b.Property<int>("AtividadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Nome")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("AtividadeId");

                    b.ToTable("Atividade");
                });

            modelBuilder.Entity("Minimal.Models.NotaAluno", b =>
                {
                    b.Property<int>("NotaAlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("AtividadeId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("NotaAlunoId");

                    b.HasIndex("AtividadeId");

                    b.HasIndex("AlunoId", "AtividadeId")
                        .IsUnique();

                    b.ToTable("NotaAluno");
                });

            modelBuilder.Entity("Minimal.Models.NotaAluno", b =>
                {
                    b.HasOne("Minimal.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Minimal.Models.Atividade", "Atividade")
                        .WithMany()
                        .HasForeignKey("AtividadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Atividade");
                });
#pragma warning restore 612, 618
        }
    }
}
