﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using smartSchool.API.Data;

namespace smartSchool.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221115013822_newInit")]
    partial class newInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("smartSchool.API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 466, DateTimeKind.Local).AddTicks(9770),
                            DataNasc = new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 1,
                            Nome = "Jessica",
                            Sobrenome = "Ketlen",
                            Telefone = "1545454"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(1403),
                            DataNasc = new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2,
                            Nome = "Paula",
                            Sobrenome = "Isabela",
                            Telefone = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(1455),
                            DataNasc = new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 3,
                            Nome = "Laura",
                            Sobrenome = "Antonia",
                            Telefone = "55668899"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(1461),
                            DataNasc = new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 4,
                            Nome = "Luiza",
                            Sobrenome = "Maria",
                            Telefone = "6565659"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(1464),
                            DataNasc = new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 5,
                            Nome = "Lucas",
                            Sobrenome = "Machado",
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(1474),
                            DataNasc = new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 6,
                            Nome = "Pedro",
                            Sobrenome = "Alvares",
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(1478),
                            DataNasc = new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 7,
                            Nome = "Paulo",
                            Sobrenome = "José",
                            Telefone = "9874512"
                        });
                });

            modelBuilder.Entity("smartSchool.API.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("smartSchool.API.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2490)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2951)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2978)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2979)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2980)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2983)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2985)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2986)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2987)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2989)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2990)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2991)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2993)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2994)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2995)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2996)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2997)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(2999)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(3000)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(3002)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(3003)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(3004)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 467, DateTimeKind.Local).AddTicks(3005)
                        });
                });

            modelBuilder.Entity("smartSchool.API.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Ciência da Computação"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Engenharia da Computação"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Recursos Humanos"
                        });
                });

            modelBuilder.Entity("smartSchool.API.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeDisciplina")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            NomeDisciplina = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 2,
                            NomeDisciplina = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 2,
                            NomeDisciplina = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 3,
                            NomeDisciplina = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            NomeDisciplina = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("smartSchool.API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Registro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 461, DateTimeKind.Local).AddTicks(2709),
                            Nome = "Nicolas",
                            Registro = 1,
                            Sobrenome = "Alexandre"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 462, DateTimeKind.Local).AddTicks(2657),
                            Nome = "Roberto",
                            Registro = 1,
                            Sobrenome = "Pereira"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 462, DateTimeKind.Local).AddTicks(2699),
                            Nome = "Pedro",
                            Registro = 1,
                            Sobrenome = "Gonçalves"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 462, DateTimeKind.Local).AddTicks(2701),
                            Nome = "Paulo",
                            Registro = 1,
                            Sobrenome = "Pedro"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataIni = new DateTime(2022, 11, 14, 22, 38, 22, 462, DateTimeKind.Local).AddTicks(2703),
                            Nome = "Alexandre",
                            Registro = 1,
                            Sobrenome = "Jesus"
                        });
                });

            modelBuilder.Entity("smartSchool.API.Models.AlunoCurso", b =>
                {
                    b.HasOne("smartSchool.API.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("smartSchool.API.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("smartSchool.API.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("smartSchool.API.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("smartSchool.API.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("smartSchool.API.Models.Disciplina", b =>
                {
                    b.HasOne("smartSchool.API.Models.Curso", "Curso")
                        .WithMany("Disciplina")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("smartSchool.API.Models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("smartSchool.API.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}