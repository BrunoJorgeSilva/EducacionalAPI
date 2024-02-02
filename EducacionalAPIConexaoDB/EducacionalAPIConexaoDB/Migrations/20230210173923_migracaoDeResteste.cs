using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducacionalAPIConexaoDB.Migrations
{
    /// <inheritdoc />
    public partial class migracaoDeResteste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Educacionais",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Educacionais");
        }
    }
}
