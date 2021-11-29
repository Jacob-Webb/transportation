using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class timeofday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b957572-d7d3-4ce2-b54b-55cb0f313e48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ce1d264-9eb6-403f-bf62-35c53f023e4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7595c5a-59ee-4de7-838a-3a594c766af7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df3b749b-0c7f-4f39-a04f-e0b29adc8898");

            migrationBuilder.DropColumn(
                name: "TimeOfDay",
                table: "EventTemplates");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "EventTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "EventTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f25ed596-b4f1-4304-87cb-27dc0a4fb542", "07b105bd-6522-4e7c-a686-798f2aa642da", "SuperAdmin", "SUPERADMIN" },
                    { "0edd9824-78d8-464e-a390-444401f6d79d", "ea5da38c-978e-45db-a95c-f586cde8ec80", "Administrator", "ADMINISTRATOR" },
                    { "ade43c8a-3532-4d40-af19-c3444642716e", "80827fb5-2a43-4e52-b2fb-8c6972b27295", "Driver", "DRIVER" },
                    { "82d39f2e-4246-4380-9931-969670867c2d", "abbee8c8-e24b-43f0-a957-ae4f971bb313", "Rider", "RIDER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0edd9824-78d8-464e-a390-444401f6d79d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d39f2e-4246-4380-9931-969670867c2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade43c8a-3532-4d40-af19-c3444642716e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f25ed596-b4f1-4304-87cb-27dc0a4fb542");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "EventTemplates");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "EventTemplates");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeOfDay",
                table: "EventTemplates",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b957572-d7d3-4ce2-b54b-55cb0f313e48", "7dc53955-3cef-4f0d-856d-eb5e1cc53e19", "SuperAdmin", "SUPERADMIN" },
                    { "df3b749b-0c7f-4f39-a04f-e0b29adc8898", "a8d66a9a-e901-404b-b5fa-f1c36c8c3880", "Administrator", "ADMINISTRATOR" },
                    { "d7595c5a-59ee-4de7-838a-3a594c766af7", "01874836-d0cf-44e8-a284-b5f20e33b9b8", "Driver", "DRIVER" },
                    { "5ce1d264-9eb6-403f-bf62-35c53f023e4d", "8e33cb8b-4216-498e-bf95-0a8b7172ff79", "Rider", "RIDER" }
                });
        }
    }
}
