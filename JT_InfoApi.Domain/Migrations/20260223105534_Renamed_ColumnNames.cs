using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_InfoApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Renamed_ColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JT_Public_Holidays_Countries_CountryId",
                table: "JT_Public_Holidays");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "JT_Public_Holidays");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "JT_Public_Holidays",
                newName: "CtyId");

            migrationBuilder.RenameIndex(
                name: "IX_JT_Public_Holidays_CountryId",
                table: "JT_Public_Holidays",
                newName: "IX_JT_Public_Holidays_CtyId");

            migrationBuilder.RenameColumn(
                name: "CountryDesc",
                table: "Countries",
                newName: "CtyDesc");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Countries",
                newName: "CtyCode");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_CountryCode",
                table: "Countries",
                newName: "IX_Countries_CtyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_JT_Public_Holidays_Countries_CtyId",
                table: "JT_Public_Holidays",
                column: "CtyId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JT_Public_Holidays_Countries_CtyId",
                table: "JT_Public_Holidays");

            migrationBuilder.RenameColumn(
                name: "CtyId",
                table: "JT_Public_Holidays",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_JT_Public_Holidays_CtyId",
                table: "JT_Public_Holidays",
                newName: "IX_JT_Public_Holidays_CountryId");

            migrationBuilder.RenameColumn(
                name: "CtyDesc",
                table: "Countries",
                newName: "CountryDesc");

            migrationBuilder.RenameColumn(
                name: "CtyCode",
                table: "Countries",
                newName: "CountryCode");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_CtyCode",
                table: "Countries",
                newName: "IX_Countries_CountryCode");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "JT_Public_Holidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_JT_Public_Holidays_Countries_CountryId",
                table: "JT_Public_Holidays",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
