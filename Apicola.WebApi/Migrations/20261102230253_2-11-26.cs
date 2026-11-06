using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apicola.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class _21126 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curados_Alimentados_Fechas_IdFechaVisita",
                table: "Curados_Alimentados");

            migrationBuilder.DropTable(
                name: "Curado_Medicamentos");

            migrationBuilder.DropTable(
                name: "DetallesCompras");

            migrationBuilder.DropTable(
                name: "Fechas");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Proveedors");

            migrationBuilder.RenameColumn(
                name: "IdFechaVisita",
                table: "Curados_Alimentados",
                newName: "Idmedicamento");

            migrationBuilder.RenameIndex(
                name: "IX_Curados_Alimentados_IdFechaVisita",
                table: "Curados_Alimentados",
                newName: "IX_Curados_Alimentados_Idmedicamento");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVisita",
                table: "Curados_Alimentados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdAlimento",
                table: "Curados_Alimentados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdColmenar",
                table: "Curados_Alimentados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Curados_Alimentados_IdAlimento",
                table: "Curados_Alimentados",
                column: "IdAlimento");

            migrationBuilder.CreateIndex(
                name: "IX_Curados_Alimentados_IdColmenar",
                table: "Curados_Alimentados",
                column: "IdColmenar");

            migrationBuilder.AddForeignKey(
                name: "FK_Curados_Alimentados_Alimentos_IdAlimento",
                table: "Curados_Alimentados",
                column: "IdAlimento",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curados_Alimentados_Colmenar_IdColmenar",
                table: "Curados_Alimentados",
                column: "IdColmenar",
                principalTable: "Colmenar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curados_Alimentados_Medicamentos_Idmedicamento",
                table: "Curados_Alimentados",
                column: "Idmedicamento",
                principalTable: "Medicamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curados_Alimentados_Alimentos_IdAlimento",
                table: "Curados_Alimentados");

            migrationBuilder.DropForeignKey(
                name: "FK_Curados_Alimentados_Colmenar_IdColmenar",
                table: "Curados_Alimentados");

            migrationBuilder.DropForeignKey(
                name: "FK_Curados_Alimentados_Medicamentos_Idmedicamento",
                table: "Curados_Alimentados");

            migrationBuilder.DropIndex(
                name: "IX_Curados_Alimentados_IdAlimento",
                table: "Curados_Alimentados");

            migrationBuilder.DropIndex(
                name: "IX_Curados_Alimentados_IdColmenar",
                table: "Curados_Alimentados");

            migrationBuilder.DropColumn(
                name: "FechaVisita",
                table: "Curados_Alimentados");

            migrationBuilder.DropColumn(
                name: "IdAlimento",
                table: "Curados_Alimentados");

            migrationBuilder.DropColumn(
                name: "IdColmenar",
                table: "Curados_Alimentados");

            migrationBuilder.RenameColumn(
                name: "Idmedicamento",
                table: "Curados_Alimentados",
                newName: "IdFechaVisita");

            migrationBuilder.RenameIndex(
                name: "IX_Curados_Alimentados_Idmedicamento",
                table: "Curados_Alimentados",
                newName: "IX_Curados_Alimentados_IdFechaVisita");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curado_Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlimento = table.Column<int>(type: "int", nullable: false),
                    IdCurado = table.Column<int>(type: "int", nullable: false),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curado_Medicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curado_Medicamentos_Alimentos_IdAlimento",
                        column: x => x.IdAlimento,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curado_Medicamentos_Curados_Alimentados_IdCurado",
                        column: x => x.IdCurado,
                        principalTable: "Curados_Alimentados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curado_Medicamentos_Medicamentos_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fechas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColmenar = table.Column<int>(type: "int", nullable: false),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fechas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fechas_Colmenar_IdColmenar",
                        column: x => x.IdColmenar,
                        principalTable: "Colmenar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocalidad = table.Column<int>(type: "int", nullable: false),
                    CodPostal = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefono = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedors_Localidades_IdLocalidad",
                        column: x => x.IdLocalidad,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedors_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedors_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesCompras_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesCompras_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdProveedor",
                table: "Compras",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Curado_Medicamentos_IdAlimento",
                table: "Curado_Medicamentos",
                column: "IdAlimento");

            migrationBuilder.CreateIndex(
                name: "IX_Curado_Medicamentos_IdCurado",
                table: "Curado_Medicamentos",
                column: "IdCurado");

            migrationBuilder.CreateIndex(
                name: "IX_Curado_Medicamentos_IdMedicamento",
                table: "Curado_Medicamentos",
                column: "IdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_IdCompra",
                table: "DetallesCompras",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompras_IdProducto",
                table: "DetallesCompras",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Fechas_IdColmenar",
                table: "Fechas",
                column: "IdColmenar");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdProveedor",
                table: "Productos",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedors_IdLocalidad",
                table: "Proveedors",
                column: "IdLocalidad");

            migrationBuilder.AddForeignKey(
                name: "FK_Curados_Alimentados_Fechas_IdFechaVisita",
                table: "Curados_Alimentados",
                column: "IdFechaVisita",
                principalTable: "Fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
