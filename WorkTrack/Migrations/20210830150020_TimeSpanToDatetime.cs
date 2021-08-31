using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkTrack.Migrations
{
    public partial class TimeSpanToDatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "WorkRecords",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "WorkRecords",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Start",
                table: "WorkRecords",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "End",
                table: "WorkRecords",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
