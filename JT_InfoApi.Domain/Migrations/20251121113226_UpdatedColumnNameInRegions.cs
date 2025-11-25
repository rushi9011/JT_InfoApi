using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_InfoApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumnNameInRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CtyName",
                table: "Regions",
                newName: "RegionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionName",
                table: "Regions",
                newName: "CtyName");
        }
    }
}
