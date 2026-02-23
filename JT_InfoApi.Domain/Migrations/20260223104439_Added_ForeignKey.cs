using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_InfoApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Added_ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "JT_Public_Holidays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JT_Public_Holidays_CountryId",
                table: "JT_Public_Holidays",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JT_Public_Holidays_Countries_CountryId",
                table: "JT_Public_Holidays",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JT_Public_Holidays_Countries_CountryId",
                table: "JT_Public_Holidays");

            migrationBuilder.DropIndex(
                name: "IX_JT_Public_Holidays_CountryId",
                table: "JT_Public_Holidays");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "JT_Public_Holidays");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RegionCode",
                table: "Regions",
                column: "RegionCode",
                unique: true);
        }
    }
}
