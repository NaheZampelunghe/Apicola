using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apicola.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class _21126V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curados_Alimentados",
                table: "Curados_Alimentados");

            migrationBuilder.RenameTable(
                name: "Curados_Alimentados",
                newName: "HistorialColmenar");

            migrationBuilder.RenameIndex(
                name: "IX_Curados_Alimentados_Idmedicamento",
                table: "HistorialColmenar",
                newName: "IX_HistorialColmenar_Idmedicamento");

            migrationBuilder.RenameIndex(
                name: "IX_Curados_Alimentados_IdColmenar",
                table: "HistorialColmenar",
                newName: "IX_HistorialColmenar_IdColmenar");

            migrationBuilder.RenameIndex(
                name: "IX_Curados_Alimentados_IdAlimento",
                table: "HistorialColmenar",
                newName: "IX_HistorialColmenar_IdAlimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorialColmenar",
                table: "HistorialColmenar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialColmenar_Alimentos_IdAlimento",
                table: "HistorialColmenar",
                column: "IdAlimento",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialColmenar_Colmenar_IdColmenar",
                table: "HistorialColmenar",
                column: "IdColmenar",
                principalTable: "Colmenar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialColmenar_Medicamentos_Idmedicamento",
                table: "HistorialColmenar",
                column: "Idmedicamento",
                principalTable: "Medicamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialColmenar_Alimentos_IdAlimento",
                table: "HistorialColmenar");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialColmenar_Colmenar_IdColmenar",
                table: "HistorialColmenar");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialColmenar_Medicamentos_Idmedicamento",
                table: "HistorialColmenar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorialColmenar",
                table: "HistorialColmenar");

            migrationBuilder.RenameTable(
                name: "HistorialColmenar",
                newName: "Curados_Alimentados");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialColmenar_Idmedicamento",
                table: "Curados_Alimentados",
                newName: "IX_Curados_Alimentados_Idmedicamento");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialColmenar_IdColmenar",
                table: "Curados_Alimentados",
                newName: "IX_Curados_Alimentados_IdColmenar");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialColmenar_IdAlimento",
                table: "Curados_Alimentados",
                newName: "IX_Curados_Alimentados_IdAlimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curados_Alimentados",
                table: "Curados_Alimentados",
                column: "Id");

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
    }
}
