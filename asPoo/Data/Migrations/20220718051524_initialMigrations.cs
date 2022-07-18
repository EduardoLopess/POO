using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    public partial class initialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    Duracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departamento_Curso",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sala = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    numeroTurma = table.Column<int>(type: "integer", nullable: false),
                    CursoID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.id);
                    table.ForeignKey(
                        name: "FK_Turma_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALuno",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    sobreNome = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    phone = table.Column<string>(type: "VARCHAR", maxLength: 12, nullable: false),
                    numeroMatricula = table.Column<int>(type: "INT", maxLength: 12, nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    TurmaId = table.Column<int>(type: "integer", nullable: true),
                    CursoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALuno", x => x.id);
                    table.ForeignKey(
                        name: "FK_ALuno_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ALuno_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cep = table.Column<int>(type: "INT", maxLength: 15, nullable: false),
                    rua = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    cidade = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    numCasa = table.Column<int>(type: "INT", maxLength: 5, nullable: false),
                    complemento = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    AlunoID = table.Column<int>(type: "integer", nullable: false),
                    ProfesssorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id);
                    table.ForeignKey(
                        name: "FK_Endereco_ALuno_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "ALuno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    sobreNome = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    cdgIndentificacao = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    fone = table.Column<string>(type: "VARCHAR", maxLength: 12, nullable: false),
                    EnderecoID = table.Column<int>(type: "integer", nullable: false),
                    TurmasId = table.Column<int>(type: "integer", nullable: true),
                    CursoID = table.Column<int>(type: "integer", nullable: false),
                    DepartamentoID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Professor_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professor_Departamento_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professor_Endereco_EnderecoID",
                        column: x => x.EnderecoID,
                        principalTable: "Endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professor_Turma_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turma",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Duracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CursoID = table.Column<int>(type: "integer", nullable: false),
                    professorId = table.Column<int>(type: "integer", nullable: true),
                    ProfesssorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materias_Professor_professorId",
                        column: x => x.professorId,
                        principalTable: "Professor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AlunoMateria",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "integer", nullable: false),
                    MateriasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoMateria", x => new { x.AlunosId, x.MateriasId });
                    table.ForeignKey(
                        name: "FK_AlunoMateria_ALuno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "ALuno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoMateria_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeriodoRealizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AlunoID = table.Column<int>(type: "integer", nullable: false),
                    MateriaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historicos_ALuno_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "ALuno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historicos_Materias_MateriaID",
                        column: x => x.MateriaID,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: false),
                    MateriaID = table.Column<int>(type: "integer", nullable: false),
                    AlunoID = table.Column<int>(type: "integer", nullable: false),
                    HistoricoID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notas_ALuno_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "ALuno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Historicos_HistoricoID",
                        column: x => x.HistoricoID,
                        principalTable: "Historicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Materias_MateriaID",
                        column: x => x.MateriaID,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALuno_CursoId",
                table: "ALuno",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ALuno_TurmaId",
                table: "ALuno",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoMateria_MateriasId",
                table: "AlunoMateria",
                column: "MateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_DepartamentoId",
                table: "Curso",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_AlunoID",
                table: "Endereco",
                column: "AlunoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_AlunoID",
                table: "Historicos",
                column: "AlunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_MateriaID",
                table: "Historicos",
                column: "MateriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_CursoID",
                table: "Materias",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_professorId",
                table: "Materias",
                column: "professorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoID",
                table: "Notas",
                column: "AlunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_HistoricoID",
                table: "Notas",
                column: "HistoricoID");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaID",
                table: "Notas",
                column: "MateriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_CursoID",
                table: "Professor",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_DepartamentoID",
                table: "Professor",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_EnderecoID",
                table: "Professor",
                column: "EnderecoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professor_TurmasId",
                table: "Professor",
                column: "TurmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_CursoID",
                table: "Turma",
                column: "CursoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoMateria");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "ALuno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
