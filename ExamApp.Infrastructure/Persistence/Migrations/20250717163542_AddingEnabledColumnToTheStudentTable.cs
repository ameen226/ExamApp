using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingEnabledColumnToTheStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Students");
        }
    }
}
