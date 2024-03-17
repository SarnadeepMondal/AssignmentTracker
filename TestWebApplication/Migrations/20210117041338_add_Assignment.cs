using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebApplication.Migrations
{
    public partial class add_Assignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignmentDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");
        }
    }
}
