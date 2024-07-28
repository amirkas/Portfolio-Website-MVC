using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassDepartment",
                table: "PortfolioDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassDepartment",
                table: "PortfolioDetails");
        }
    }
}
