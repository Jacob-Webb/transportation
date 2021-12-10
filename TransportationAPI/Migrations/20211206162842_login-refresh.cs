using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class loginrefresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00cdcc3e-95d6-43d6-b85d-60d4bb9a5f26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9cfc8bc-887f-4ccf-8460-633eb2c4592e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc7dcd25-9c08-4be7-a08e-087e3cf4ec8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e808c521-96c9-4e1e-a21b-2afb166b13b1");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "846e2632-f96f-455b-8816-ad8cf17e1d97", "43673e23-57c1-4495-9813-87507ebd0c22", "SuperAdmin", "SUPERADMIN" },
                    { "8c58fd63-e85f-42e8-8000-0d39a88b4b08", "399f50f4-ed04-410b-82af-1247d5e8947b", "Administrator", "ADMINISTRATOR" },
                    { "deffb0b8-79f0-4b91-8d59-29c4ae1728d8", "c034831b-79bb-4c73-b146-493c3d55808b", "Driver", "DRIVER" },
                    { "a28af549-b22c-43c4-974f-fc86ff5c2e09", "972434ed-9120-4170-9246-3417f07a8218", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "846e2632-f96f-455b-8816-ad8cf17e1d97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c58fd63-e85f-42e8-8000-0d39a88b4b08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a28af549-b22c-43c4-974f-fc86ff5c2e09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deffb0b8-79f0-4b91-8d59-29c4ae1728d8");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc7dcd25-9c08-4be7-a08e-087e3cf4ec8b", "8d9c655a-35af-46cb-b4e1-10351759fd0d", "SuperAdmin", "SUPERADMIN" },
                    { "b9cfc8bc-887f-4ccf-8460-633eb2c4592e", "20cc4a0c-2328-4c35-aad8-c04aadc7fa1b", "Administrator", "ADMINISTRATOR" },
                    { "00cdcc3e-95d6-43d6-b85d-60d4bb9a5f26", "b351aed5-1e5a-4f54-bd29-1d2b560c6d42", "Driver", "DRIVER" },
                    { "e808c521-96c9-4e1e-a21b-2afb166b13b1", "957164d8-795d-44d4-8e65-841010f97738", "Rider", "RIDER" }
                });
        }
    }
}
