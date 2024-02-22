using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducacionalAPIConexaoDB.Migrations
{
    /// <inheritdoc />
    public partial class EnglishDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Email_Aluno_AlunoId",
                table: "Email");

            migrationBuilder.DropTable(
                name: "Educacionais");

            migrationBuilder.DropTable(
                name: "Faltas");

            migrationBuilder.RenameColumn(
                name: "SerieTurma",
                table: "Turma",
                newName: "YearGrade");

            migrationBuilder.RenameColumn(
                name: "LetraTurma",
                table: "Turma",
                newName: "LetterGrade");

            migrationBuilder.RenameColumn(
                name: "AnoTurma",
                table: "Turma",
                newName: "GradeClassRoom");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Turma",
                newName: "ClassroomId");

            migrationBuilder.RenameColumn(
                name: "EmailResponsavel",
                table: "Email",
                newName: "ResponsibleEmail");

            migrationBuilder.RenameColumn(
                name: "EmailPrincipal",
                table: "Email",
                newName: "MainEmail");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Email",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Email_AlunoId",
                table: "Email",
                newName: "IX_Email_StudentId");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "Aluno",
                newName: "ClassRoomId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Aluno",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Aluno",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_TurmaId",
                table: "Aluno",
                newName: "IX_Aluno_ClassRoomId");

            migrationBuilder.CreateTable(
                name: "Educationals",
                columns: table => new
                {
                    EducationalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EducationalCod = table.Column<int>(type: "int", nullable: false),
                    NameInstituition = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodInstitution = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educationals", x => x.EducationalId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lacks",
                columns: table => new
                {
                    LackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LackDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    HealthCertificate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lacks", x => x.LackId);
                    table.ForeignKey(
                        name: "FK_Lacks_Aluno_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Aluno",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lacks_Turma_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "Turma",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Lacks_ClassRoomId",
                table: "Lacks",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lacks_StudentId",
                table: "Lacks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_ClassRoomId",
                table: "Aluno",
                column: "ClassRoomId",
                principalTable: "Turma",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Email_Aluno_StudentId",
                table: "Email",
                column: "StudentId",
                principalTable: "Aluno",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_ClassRoomId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Email_Aluno_StudentId",
                table: "Email");

            migrationBuilder.DropTable(
                name: "Educationals");

            migrationBuilder.DropTable(
                name: "Lacks");

            migrationBuilder.RenameColumn(
                name: "YearGrade",
                table: "Turma",
                newName: "SerieTurma");

            migrationBuilder.RenameColumn(
                name: "LetterGrade",
                table: "Turma",
                newName: "LetraTurma");

            migrationBuilder.RenameColumn(
                name: "GradeClassRoom",
                table: "Turma",
                newName: "AnoTurma");

            migrationBuilder.RenameColumn(
                name: "ClassroomId",
                table: "Turma",
                newName: "TurmaId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Email",
                newName: "AlunoId");

            migrationBuilder.RenameColumn(
                name: "ResponsibleEmail",
                table: "Email",
                newName: "EmailResponsavel");

            migrationBuilder.RenameColumn(
                name: "MainEmail",
                table: "Email",
                newName: "EmailPrincipal");

            migrationBuilder.RenameIndex(
                name: "IX_Email_StudentId",
                table: "Email",
                newName: "IX_Email_AlunoId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Aluno",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ClassRoomId",
                table: "Aluno",
                newName: "TurmaId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Aluno",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_ClassRoomId",
                table: "Aluno",
                newName: "IX_Aluno_TurmaId");

            migrationBuilder.CreateTable(
                name: "Educacionais",
                columns: table => new
                {
                    EducacionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodInstituicao = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EducacionalCod = table.Column<int>(type: "int", nullable: false),
                    NomeInstituicao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educacionais", x => x.EducacionalId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Faltas",
                columns: table => new
                {
                    FaltaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    Atestado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ativa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DiaFalta = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faltas", x => x.FaltaId);
                    table.ForeignKey(
                        name: "FK_Faltas_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faltas_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Faltas_AlunoId",
                table: "Faltas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Faltas_TurmaId",
                table: "Faltas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "TurmaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Email_Aluno_AlunoId",
                table: "Email",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
