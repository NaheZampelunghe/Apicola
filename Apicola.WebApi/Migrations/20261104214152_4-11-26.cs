using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apicola.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class _41126 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialColmenar_Medicamentos_Idmedicamento",
                table: "HistorialColmenar");

            migrationBuilder.RenameColumn(
                name: "Idmedicamento",
                table: "HistorialColmenar",
                newName: "IdMedicamento");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialColmenar_Idmedicamento",
                table: "HistorialColmenar",
                newName: "IX_HistorialColmenar_IdMedicamento");

            migrationBuilder.AlterColumn<int>(
                name: "IdMedicamento",
                table: "HistorialColmenar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdColmenar",
                table: "HistorialColmenar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAlimento",
                table: "HistorialColmenar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialColmenar_Medicamentos_IdMedicamento",
                table: "HistorialColmenar",
                column: "IdMedicamento",
                principalTable: "Medicamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialColmenar_Medicamentos_IdMedicamento",
                table: "HistorialColmenar");

            migrationBuilder.RenameColumn(
                name: "IdMedicamento",
                table: "HistorialColmenar",
                newName: "Idmedicamento");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialColmenar_IdMedicamento",
                table: "HistorialColmenar",
                newName: "IX_HistorialColmenar_Idmedicamento");

            migrationBuilder.AlterColumn<int>(
                name: "Idmedicamento",
                table: "HistorialColmenar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdColmenar",
                table: "HistorialColmenar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdAlimento",
                table: "HistorialColmenar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialColmenar_Medicamentos_Idmedicamento",
                table: "HistorialColmenar",
                column: "Idmedicamento",
                principalTable: "Medicamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
