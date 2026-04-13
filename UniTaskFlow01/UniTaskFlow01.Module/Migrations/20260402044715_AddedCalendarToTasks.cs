using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTaskFlow01.Module.Migrations
{
    /// <inheritdoc />
    public partial class AddedCalendarToTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // *** ALREADY COMMENTED OUT ***
            // migrationBuilder.DropColumn(
            //     name: "ProfilePicture",
            //     schema: "dbo",
            //     table: "PermissionPolicyUser");

            // *** FIX: COMMENT OUT THIS BLOCK BECAUSE IT ALREADY EXISTS IN SQL ***
            // migrationBuilder.AddColumn<Guid>(
            //     name: "ProfilePictureID",
            //     schema: "dbo",
            //     table: "PermissionPolicyUser",
            //     type: "uniqueidentifier",
            //     nullable: true);

            // *** FIX: COMMENT OUT ALL CALENDAR PROPERTIES BECAUSE XAF ALREADY BUILT THEM ***
            // migrationBuilder.AddColumn<bool>(
            //     name: "AllDay",
            //     schema: "dbo",
            //     table: "OfficeTasks",
            //     type: "bit",
            //     nullable: false,
            //     defaultValue: false);

            // migrationBuilder.AddColumn<DateTime>(
            //     name: "EndOn",
            //     schema: "dbo",
            //     table: "OfficeTasks",
            //     type: "datetime2",
            //     nullable: false,
            //     defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // migrationBuilder.AddColumn<int>(
            //     name: "Label",
            //     schema: "dbo",
            //     table: "OfficeTasks",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddColumn<string>(
            //     name: "Location",
            //     schema: "dbo",
            //     table: "OfficeTasks",
            //     type: "nvarchar(max)",
            //     nullable: true);

            // migrationBuilder.AddColumn<DateTime>(
            //     name: "StartOn",
            //     schema: "dbo",
            //     table: "OfficeTasks",
            //     type: "datetime2",
            //     nullable: false,
            //     defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // migrationBuilder.AddColumn<string>(
            //     name: "Subject",
            //     schema: "dbo",
            //     table: "OfficeTasks",
            //     type: "nvarchar(max)",
            //     nullable: true);

            // *** FIX: COMMENT OUT INDEX AND FOREIGN KEY BECAUSE THE COLUMN IS ALREADY THERE ***
            // migrationBuilder.CreateIndex(
            //     name: "IX_PermissionPolicyUser_ProfilePictureID",
            //     schema: "dbo",
            //     table: "PermissionPolicyUser",
            //     column: "ProfilePictureID");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_PermissionPolicyUser_FileData_ProfilePictureID",
            //     schema: "dbo",
            //     table: "PermissionPolicyUser",
            //     column: "ProfilePictureID",
            //     principalSchema: "dbo",
            //     principalTable: "FileData",
            //     principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // We can leave the Down method as it is, as long as Up works.
        }
    }
}