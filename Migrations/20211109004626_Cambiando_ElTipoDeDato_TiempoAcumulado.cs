using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_PrandiFabiel_20190281.Migrations
{
    public partial class Cambiando_ElTipoDeDato_TiempoAcumulado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TiempoAcumulado",
                table: "Tareas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 1,
                column: "TiempoAcumulado",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 2,
                column: "TiempoAcumulado",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 3,
                column: "TiempoAcumulado",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 4,
                column: "TiempoAcumulado",
                value: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TiempoAcumulado",
                table: "Tareas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 1,
                column: "TiempoAcumulado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 2,
                column: "TiempoAcumulado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 3,
                column: "TiempoAcumulado",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: 4,
                column: "TiempoAcumulado",
                value: 0);
        }
    }
}
