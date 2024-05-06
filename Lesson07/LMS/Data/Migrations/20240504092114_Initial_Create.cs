using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Number = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Salgrades",
                columns: table => new
                {
                    Grade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowestSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HighestSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salgrades", x => x.Grade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Number = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hiredate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepartmentNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManagerNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentNumber",
                        column: x => x.DepartmentNumber,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerNumber",
                        column: x => x.ManagerNumber,
                        principalTable: "Employees",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentNumber",
                table: "Employees",
                column: "DepartmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerNumber",
                table: "Employees",
                column: "ManagerNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Salgrades");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
