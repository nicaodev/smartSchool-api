using Microsoft.EntityFrameworkCore;
using smartSchool.API.Models;
using System;
using System.Collections.Generic;

namespace smartSchool.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }

        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });

            builder.Entity<AlunoCurso>()
                .HasKey(ac => new { ac.AlunoId, ac.CursoId });

            // Carga inicial
            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1,"Nicolas",1, "Alexandre"),
                    new Professor(2, "Roberto",1, "Pereira"),
                    new Professor(3, "Pedro", 1, "Gonçalves"),
                    new Professor(4, "Paulo", 1, "Pedro"),
                    new Professor(5, "Alexandre", 1, "Jesus"),
                });

            builder.Entity<Curso>()
                .HasData(new List<Curso>()
                {
                    new Curso(1,"Ciência da Computação"),
                    new Curso(2,"Engenharia da Computação"),
                    new Curso(3,"Recursos Humanos")
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática",1,1),
                    new Disciplina(2, "Física", 2,2),
                    new Disciplina(3, "Português", 3,2),
                    new Disciplina(4, "Inglês", 4,3),
                    new Disciplina(5, "Programação", 5,1)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1,1,"Jessica", "Ketlen","1545454",DateTime.Parse("02/07/2000")),
                    new Aluno(2,2, "Paula", "Isabela", "3354288",DateTime.Parse("02/07/2000")),
                    new Aluno(3,3, "Laura", "Antonia", "55668899",DateTime.Parse("02/07/2000")),
                    new Aluno(4,4, "Luiza", "Maria", "6565659",DateTime.Parse("02/07/2000")),
                    new Aluno(5,5, "Lucas", "Machado", "565685415",DateTime.Parse("02/07/2000")),
                    new Aluno(6,6, "Pedro", "Alvares", "456454545",DateTime.Parse("02/07/2000")),
                    new Aluno(7,7, "Paulo", "José", "9874512",DateTime.Parse("02/07/2000"))
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });
        }
    }
}