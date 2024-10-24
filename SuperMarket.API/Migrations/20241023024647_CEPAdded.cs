using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.API.Migrations
{
    /// <inheritdoc />
    public partial class CEPAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Employees",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Employees",
                newName: "PostalCode");
        }
    }
}
