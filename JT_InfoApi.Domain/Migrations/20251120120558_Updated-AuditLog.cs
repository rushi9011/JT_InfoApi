using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JT_InfoApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAuditLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QueryString",
                table: "ApiAuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponseBody",
                table: "ApiAuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueryString",
                table: "ApiAuditLogs");

            migrationBuilder.DropColumn(
                name: "ResponseBody",
                table: "ApiAuditLogs");
        }
    }
}
