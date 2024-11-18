using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Migrations
{
    /// <inheritdoc />
    public partial class changedNameandTitletoBrandandModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
