using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernamePasswordToSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameSeller",
                table: "sellers",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "sellers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "sellers",
                newName: "NameSeller");
        }
    }
}
