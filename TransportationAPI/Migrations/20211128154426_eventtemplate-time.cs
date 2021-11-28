using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class eventtemplatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f59b075-f1e0-46f3-af67-371efc484fa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d4f0469-fea5-45e0-bd2c-f59b79ac44c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bc3d221-6716-44d0-8c02-0c94b4871c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e3e40ef-daf9-449d-be11-95c126a64467");

            migrationBuilder.DropColumn(
                name: "TimeOfDay",
                table: "EventTemplates");

            migrationBuilder.RenameColumn(
                name: "eventDateTime",
                table: "Events",
                newName: "EventDateTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Events",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
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
                    { "a839116a-490b-436b-9a64-5666b4968c6f", "c08ba5e6-cf28-4b5c-a00f-3d3df2ee37ee", "SuperAdmin", "SUPERADMIN" },
                    { "7996dc5b-25a7-4ac8-90f3-5f6985776020", "75da6f21-caa5-47e7-938c-0df428e2dcc1", "Administrator", "ADMINISTRATOR" },
                    { "8bed19e0-e3e9-4094-8ddb-9e0296b83c81", "b3afa4b0-151e-4e04-bfb9-77b1f3b2fa9d", "Driver", "DRIVER" },
                    { "232e5e1e-fc2d-461a-8ff5-45c76778c16a", "baceeb2d-0529-40a5-91f8-0ce21933dde7", "Rider", "RIDER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "232e5e1e-fc2d-461a-8ff5-45c76778c16a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7996dc5b-25a7-4ac8-90f3-5f6985776020");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bed19e0-e3e9-4094-8ddb-9e0296b83c81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a839116a-490b-436b-9a64-5666b4968c6f");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "EventTemplates");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "EventTemplates");

            migrationBuilder.RenameColumn(
                name: "EventDateTime",
                table: "Events",
                newName: "eventDateTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "id");

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
                    { "2f59b075-f1e0-46f3-af67-371efc484fa8", "3594af51-675a-4f59-8805-5717e5677cab", "SuperAdmin", "SUPERADMIN" },
                    { "9e3e40ef-daf9-449d-be11-95c126a64467", "3d188618-fa96-4063-acfe-b47d033f3482", "Administrator", "ADMINISTRATOR" },
                    { "5d4f0469-fea5-45e0-bd2c-f59b79ac44c5", "e8de43f9-9e66-481d-bc2e-d14d0e4a2c42", "Driver", "DRIVER" },
                    { "9bc3d221-6716-44d0-8c02-0c94b4871c4d", "76b831ba-77b9-4b82-872d-72ee51c3d992", "Rider", "RIDER" }
                });
        }
    }
}
