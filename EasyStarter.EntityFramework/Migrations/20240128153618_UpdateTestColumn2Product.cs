using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyStarter.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTestColumn2Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestColumn1",
                table: "Product",
                newName: "TestColumn2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestColumn2",
                table: "Product",
                newName: "TestColumn1");
        }
    }
}
