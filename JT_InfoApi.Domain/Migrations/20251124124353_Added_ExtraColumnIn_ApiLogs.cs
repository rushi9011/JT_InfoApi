using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_InfoApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Added_ExtraColumnIn_ApiLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestBody",
                table: "ApiAuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestBody",
                table: "ApiAuditLogs");
        }
    }
}
