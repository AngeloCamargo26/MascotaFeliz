using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaVeterinaria.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "propietarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "veterinarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mascotas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    estadoSalud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    propietarioid = table.Column<int>(type: "int", nullable: true),
                    veterinarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascotas", x => x.id);
                    table.ForeignKey(
                        name: "FK_mascotas_propietarios_propietarioid",
                        column: x => x.propietarioid,
                        principalTable: "propietarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_mascotas_veterinarios_veterinarioid",
                        column: x => x.veterinarioid,
                        principalTable: "veterinarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "historiasClinicas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaApertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaCierre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mascotaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiasClinicas", x => x.id);
                    table.ForeignKey(
                        name: "FK_historiasClinicas_mascotas_mascotaid",
                        column: x => x.mascotaid,
                        principalTable: "mascotas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "visitas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaSalida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temperatura = table.Column<double>(type: "float", nullable: false),
                    peso = table.Column<double>(type: "float", nullable: false),
                    frecuenciaRespiratoria = table.Column<double>(type: "float", nullable: false),
                    frecuenciaCardiaca = table.Column<double>(type: "float", nullable: false),
                    estadoAnimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    historiasClinicasid = table.Column<int>(type: "int", nullable: true),
                    propietarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitas", x => x.id);
                    table.ForeignKey(
                        name: "FK_visitas_historiasClinicas_historiasClinicasid",
                        column: x => x.historiasClinicasid,
                        principalTable: "historiasClinicas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_visitas_propietarios_propietarioid",
                        column: x => x.propietarioid,
                        principalTable: "propietarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_historiasClinicas_mascotaid",
                table: "historiasClinicas",
                column: "mascotaid");

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_propietarioid",
                table: "mascotas",
                column: "propietarioid");

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_veterinarioid",
                table: "mascotas",
                column: "veterinarioid");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_historiasClinicasid",
                table: "visitas",
                column: "historiasClinicasid");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_propietarioid",
                table: "visitas",
                column: "propietarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "visitas");

            migrationBuilder.DropTable(
                name: "historiasClinicas");

            migrationBuilder.DropTable(
                name: "mascotas");

            migrationBuilder.DropTable(
                name: "propietarios");

            migrationBuilder.DropTable(
                name: "veterinarios");
        }
    }
}
