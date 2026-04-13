using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTaskFlow01.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "dbo",
                table: "PermissionPolicyUser",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "dbo",
                table: "PermissionPolicyUser");
        }
    }
}
