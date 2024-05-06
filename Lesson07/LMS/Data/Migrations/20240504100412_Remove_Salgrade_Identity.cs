using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Salgrade_Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Salgrades",
                table: "Salgrades");
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Salgrades");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Salgrades",
                nullable: false,
                type: "int");
            migrationBuilder.AddPrimaryKey(
                name: "PK_Salgrades",
                table: "Salgrades",
                column: "Grade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Salgrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
