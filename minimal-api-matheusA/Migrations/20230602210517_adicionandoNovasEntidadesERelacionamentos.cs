using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api_matheusA.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoNovasEntidadesERelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Aluno");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Aluno",
                newName: "AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "AlunoId");

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    AtividadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.AtividadeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotaAluno",
                columns: table => new
                {
                    NotaAlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaAluno", x => x.NotaAlunoId);
                    table.ForeignKey(
                        name: "FK_NotaAluno_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaAluno_Atividade_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividade",
                        principalColumn: "AtividadeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NotaAluno_AlunoId_AtividadeId",
                table: "NotaAluno",
                columns: new[] { "AlunoId", "AtividadeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaAluno_AtividadeId",
                table: "NotaAluno",
                column: "AtividadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaAluno");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.RenameTable(
                name: "Aluno",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.AddColumn<double>(
                name: "Nota",
                table: "Usuarios",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }
    }
}
