using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace smartSchool.API.Migrations
{
    public partial class changeToMySQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Matricula = table.Column<int>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Registro = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CargaHoraria = table.Column<int>(nullable: false),
                    NomeDisciplina = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(379), new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jessica", "Ketlen", "1545454" },
                    { 2, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(2176), new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(2235), new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(2241), new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(2245), new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(2254), new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(2258), new DateTime(2000, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Ciência da Computação" },
                    { 2, "Engenharia da Computação" },
                    { 3, "Recursos Humanos" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 267, DateTimeKind.Local).AddTicks(1560), "Nicolas", 1, "Alexandre", null },
                    { 2, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 268, DateTimeKind.Local).AddTicks(97), "Roberto", 1, "Pereira", null },
                    { 3, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 268, DateTimeKind.Local).AddTicks(156), "Pedro", 1, "Gonçalves", null },
                    { 4, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 268, DateTimeKind.Local).AddTicks(158), "Paulo", 1, "Pedro", null },
                    { 5, true, null, new DateTime(2022, 11, 18, 22, 18, 12, 268, DateTimeKind.Local).AddTicks(159), "Alexandre", 1, "Jesus", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 2, "Física", null, 2 },
                    { 3, 0, 2, "Português", null, 3 },
                    { 4, 0, 3, "Inglês", null, 4 },
                    { 5, 0, 1, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4305), null },
                    { 4, 5, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4318), null },
                    { 2, 5, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4310), null },
                    { 1, 5, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4303), null },
                    { 7, 4, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4332), null },
                    { 6, 4, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4327), null },
                    { 5, 4, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4320), null },
                    { 4, 4, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4317), null },
                    { 1, 4, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4283), null },
                    { 7, 3, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4331), null },
                    { 5, 5, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4321), null },
                    { 6, 3, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4325), null },
                    { 7, 2, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4329), null },
                    { 6, 2, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4323), null },
                    { 3, 2, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4312), null },
                    { 2, 2, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4306), null },
                    { 1, 2, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(3807), null },
                    { 7, 1, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4328), null },
                    { 6, 1, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4322), null },
                    { 4, 1, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4316), null },
                    { 3, 1, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4311), null },
                    { 3, 3, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4313), null },
                    { 7, 5, null, new DateTime(2022, 11, 18, 22, 18, 12, 304, DateTimeKind.Local).AddTicks(4333), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
