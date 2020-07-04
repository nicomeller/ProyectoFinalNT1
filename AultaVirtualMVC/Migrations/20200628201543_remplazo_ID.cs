using Microsoft.EntityFrameworkCore.Migrations;

namespace AulaVirtualMVC.Migrations
{
    public partial class remplazo_ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioId",
                table: "Suscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Suscripciones",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Suscripciones_UsuarioId",
                table: "Suscripciones",
                newName: "IX_Suscripciones_UsuarioID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDUsuario",
                table: "Suscripciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioID",
                table: "Suscripciones",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioID",
                table: "Suscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IDUsuario",
                table: "Suscripciones");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Suscripciones",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Suscripciones_UsuarioID",
                table: "Suscripciones",
                newName: "IX_Suscripciones_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioId",
                table: "Suscripciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
