using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class timespantypeforeventtemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02d0418f-ca74-4828-a3ba-a3a032876a7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dbcb848-98c4-4f83-bba0-ada531ed35cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8b6dd94-9e18-47e0-ba38-818d101523a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e26a24d9-2737-49af-9b66-2d03a5af4507");

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
                    { "1c0a56dc-4118-4097-ac1f-bfe63a4d4588", "0ef34ce1-15b7-49a2-9d44-f65b62742893", "SuperAdmin", "SUPERADMIN" },
                    { "b9e4cd0e-38a4-44c0-ba9a-069bf561d4d3", "f619d6e6-b68e-4730-9004-69af38db7bd7", "Administrator", "ADMINISTRATOR" },
                    { "61323dd8-db81-4b5e-9c62-245a844e493c", "915f4b1a-14f1-4ca5-8a7a-f92af661b928", "Driver", "DRIVER" },
                    { "7f752681-8d2a-4aa5-8ed1-66005c1db9d0", "1160fd7d-277a-4f10-b80d-b8e40b69cb19", "Rider", "RIDER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c0a56dc-4118-4097-ac1f-bfe63a4d4588");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61323dd8-db81-4b5e-9c62-245a844e493c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f752681-8d2a-4aa5-8ed1-66005c1db9d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9e4cd0e-38a4-44c0-ba9a-069bf561d4d3");

            migrationBuilder.DropColumn(
                name: "TimeOfDay",
                table: "EventTemplates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02d0418f-ca74-4828-a3ba-a3a032876a7b", "059507ba-a50c-4955-a780-04cf9d712152", "SuperAdmin", "SUPERADMIN" },
                    { "7dbcb848-98c4-4f83-bba0-ada531ed35cd", "c4562379-6f57-42b2-aa03-fd44a4fa781c", "Administrator", "ADMINISTRATOR" },
                    { "e26a24d9-2737-49af-9b66-2d03a5af4507", "8086c926-9ee2-4aed-9343-f5d24e707f40", "Driver", "DRIVER" },
                    { "a8b6dd94-9e18-47e0-ba38-818d101523a0", "c387a2aa-a31a-4f58-8b63-17de7b47d296", "Rider", "RIDER" }
                });
        }
    }
}
