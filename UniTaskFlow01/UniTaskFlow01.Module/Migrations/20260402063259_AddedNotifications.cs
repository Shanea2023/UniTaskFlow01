using System;
using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace UniTaskFlow01.Module.Migrations

{
    public partial class AddedNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                schema: "dbo",
                table: "OfficeTasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "AlarmTime",
                schema: "dbo",
                table: "OfficeTasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPostponed",
                schema: "dbo",
                table: "OfficeTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "dbo",
                table: "OfficeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.CreateTable(
            //    name: "SchedulerEvents",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        StartOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        AllDay = table.Column<bool>(type: "bit", nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Label = table.Column<int>(type: "int", nullable: false),
            //        Status = table.Column<int>(type: "int", nullable: false),
            //        Type = table.Column<int>(type: "int", nullable: false),
            //        AlarmTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsPostponed = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SchedulerEvents", x => x.ID);
            //    });

        //    migrationBuilder.CreateTable(
        //        name: "SubTasks",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //            Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsCompleted = table.Column<bool>(type: "bit", nullable: false),
        //            MainTaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubTasks", x => x.ID);
        //            table.ForeignKey(
        //                name: "FK_SubTasks_OfficeTasks_MainTaskID",
        //                column: x => x.MainTaskID,
        //                principalSchema: "dbo",
        //                principalTable: "OfficeTasks",
        //                principalColumn: "ID");
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SubTasks_MainTaskID",
        //        schema: "dbo",
        //        table: "SubTasks",
        //        column: "MainTaskID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulerEvents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubTasks",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "AlarmTime",
                schema: "dbo",
                table: "OfficeTasks");

            migrationBuilder.DropColumn(
                name: "IsPostponed",
                schema: "dbo",
                table: "OfficeTasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "dbo",
                table: "OfficeTasks");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                schema: "dbo",
                table: "OfficeTasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

