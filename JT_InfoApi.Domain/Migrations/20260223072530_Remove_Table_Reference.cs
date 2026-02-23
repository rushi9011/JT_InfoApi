using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_InfoApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Table_Reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JT_Public_Holidays_Regions_RegionId",
                table: "JT_Public_Holidays");

            migrationBuilder.DropIndex(
                name: "IX_JT_Public_Holidays_RegionId",
                table: "JT_Public_Holidays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JT_Public_Holidays_RegionId",
                table: "JT_Public_Holidays",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_JT_Public_Holidays_Regions_RegionId",
                table: "JT_Public_Holidays",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
