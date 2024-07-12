using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee_Details");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee_Details",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Employee_Career_Level = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Employee_Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Employee_Experience = table.Column<float>(type: "real", nullable: false),
                    Employee_Full_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Employee_Join_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Employee_Skill = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Off_Shore_End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Off_Shore_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Details", x => x.Employee_Id);
                });
        }
    }
}
