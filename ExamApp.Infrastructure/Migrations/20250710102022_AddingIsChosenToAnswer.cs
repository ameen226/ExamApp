using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsChosenToAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChosen",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChosen",
                table: "Answers");
        }
    }
}
