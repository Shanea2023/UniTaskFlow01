using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTaskFlow01.Module.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSpreadsheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpreadsheetData",
                schema: "dbo",
                table: "OfficeTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SpreadsheetData",
                schema: "dbo",
                table: "OfficeTasks",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
