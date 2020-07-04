using Microsoft.EntityFrameworkCore.Migrations;

namespace AulaVirtualMVC.Migrations
{
    public partial class suprimoClassAulaVirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_AulasVirtuales_AulaVirtualId",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_AulasVirtuales_AulaVirtualId",
                table: "Suscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_AulasVirtuales_AulaVirtualId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "AulasVirtuales");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_AulaVirtualId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Suscripciones_AulaVirtualId",
                table: "Suscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_AulaVirtualId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "AulaVirtualId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AulaVirtualId",
                table: "Suscripciones");

            migrationBuilder.DropColumn(
                name: "AulaVirtualId",
                table: "Cursos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AulaVirtualId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AulaVirtualId",
                table: "Suscripciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AulaVirtualId",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AulasVirtuales",
                columns: table => new
                {
                    AulaVirtualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasVirtuales", x => x.AulaVirtualId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AulaVirtualId",
                table: "Usuarios",
                column: "AulaVirtualId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_AulaVirtualId",
                table: "Suscripciones",
                column: "AulaVirtualId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AulaVirtualId",
                table: "Cursos",
                column: "AulaVirtualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_AulasVirtuales_AulaVirtualId",
                table: "Cursos",
                column: "AulaVirtualId",
                principalTable: "AulasVirtuales",
                principalColumn: "AulaVirtualId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_AulasVirtuales_AulaVirtualId",
                table: "Suscripciones",
                column: "AulaVirtualId",
                principalTable: "AulasVirtuales",
                principalColumn: "AulaVirtualId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_AulasVirtuales_AulaVirtualId",
                table: "Usuarios",
                column: "AulaVirtualId",
                principalTable: "AulasVirtuales",
                principalColumn: "AulaVirtualId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
