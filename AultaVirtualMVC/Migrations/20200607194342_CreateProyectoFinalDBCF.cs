using Microsoft.EntityFrameworkCore.Migrations;

namespace AulaVirtualMVC.Migrations
{
    public partial class CreateProyectoFinalDBCF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AulasVirtuales",
                columns: table => new
                {
                    AulaVirtualId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasVirtuales", x => x.AulaVirtualId);
                });

            migrationBuilder.CreateTable(
                name: "MediosPagos",
                columns: table => new
                {
                    MedioPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosPagos", x => x.MedioPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    AulaVirtualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Cursos_AulasVirtuales_AulaVirtualId",
                        column: x => x.AulaVirtualId,
                        principalTable: "AulasVirtuales",
                        principalColumn: "AulaVirtualId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    AulaVirtualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_AulasVirtuales_AulaVirtualId",
                        column: x => x.AulaVirtualId,
                        principalTable: "AulasVirtuales",
                        principalColumn: "AulaVirtualId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contenidos",
                columns: table => new
                {
                    ContenidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Archivo = table.Column<string>(nullable: true),
                    CursoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenidos", x => x.ContenidoId);
                    table.ForeignKey(
                        name: "FK_Contenidos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                columns: table => new
                {
                    SuscripcionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: true),
                    CursoId = table.Column<int>(nullable: true),
                    ValorPago = table.Column<double>(nullable: false),
                    MedioPagoId = table.Column<int>(nullable: true),
                    AulaVirtualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.SuscripcionId);
                    table.ForeignKey(
                        name: "FK_Suscripciones_AulasVirtuales_AulaVirtualId",
                        column: x => x.AulaVirtualId,
                        principalTable: "AulasVirtuales",
                        principalColumn: "AulaVirtualId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suscripciones_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suscripciones_MediosPagos_MedioPagoId",
                        column: x => x.MedioPagoId,
                        principalTable: "MediosPagos",
                        principalColumn: "MedioPagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suscripciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contenidos_CursoId",
                table: "Contenidos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AulaVirtualId",
                table: "Cursos",
                column: "AulaVirtualId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_AulaVirtualId",
                table: "Suscripciones",
                column: "AulaVirtualId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_CursoId",
                table: "Suscripciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_MedioPagoId",
                table: "Suscripciones",
                column: "MedioPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_UsuarioId",
                table: "Suscripciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AulaVirtualId",
                table: "Usuarios",
                column: "AulaVirtualId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contenidos");

            migrationBuilder.DropTable(
                name: "Suscripciones");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "MediosPagos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AulasVirtuales");
        }
    }
}
