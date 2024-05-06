using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_City_To_Department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityNumber",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CityNumber",
                table: "Departments",
                column: "CityNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_City_CityNumber",
                table: "Departments",
                column: "CityNumber",
                principalTable: "City",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_City_CityNumber",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CityNumber",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CityNumber",
                table: "Departments");
        }
    }
}
