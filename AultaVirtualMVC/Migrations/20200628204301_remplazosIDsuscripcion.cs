using Microsoft.EntityFrameworkCore.Migrations;

namespace AulaVirtualMVC.Migrations
{
    public partial class remplazosIDsuscripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_Cursos_CursoId",
                table: "Suscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_MediosPagos_MedioPagoId",
                table: "Suscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioID",
                table: "Suscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediosPagos",
                table: "MediosPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "IDUsuario",
                table: "Suscripciones");

            migrationBuilder.DropColumn(
                name: "MedioPagoId",
                table: "MediosPagos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Suscripciones",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Suscripciones_UsuarioID",
                table: "Suscripciones",
                newName: "IX_Suscripciones_UsuarioId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Suscripciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedioPagoId",
                table: "Suscripciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Suscripciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "MediosPagos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Cursos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediosPagos",
                table: "MediosPagos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_Cursos_CursoId",
                table: "Suscripciones",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_MediosPagos_MedioPagoId",
                table: "Suscripciones",
                column: "MedioPagoId",
                principalTable: "MediosPagos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioId",
                table: "Suscripciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_Cursos_CursoId",
                table: "Suscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_MediosPagos_MedioPagoId",
                table: "Suscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioId",
                table: "Suscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediosPagos",
                table: "MediosPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "MediosPagos");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Suscripciones",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Suscripciones_UsuarioId",
                table: "Suscripciones",
                newName: "IX_Suscripciones_UsuarioID");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Suscripciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedioPagoId",
                table: "Suscripciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Suscripciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDUsuario",
                table: "Suscripciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedioPagoId",
                table: "MediosPagos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediosPagos",
                table: "MediosPagos",
                column: "MedioPagoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_Cursos_CursoId",
                table: "Suscripciones",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_MediosPagos_MedioPagoId",
                table: "Suscripciones",
                column: "MedioPagoId",
                principalTable: "MediosPagos",
                principalColumn: "MedioPagoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripciones_Usuarios_UsuarioID",
                table: "Suscripciones",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
