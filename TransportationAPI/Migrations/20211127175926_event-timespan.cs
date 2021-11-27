using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class eventtimespan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b9ab474-6255-4268-8f7c-871bf48b5c0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b52932c-ff02-4c3d-a214-b98c4199e7b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54cb8096-0878-4c17-bb36-af28eb645f8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d87f4ceb-1532-4020-a80a-096271569ea9");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeOfDay",
                table: "EventTemplates",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a9cd3c13-5f10-4e21-bade-52fb56dda8cc", "90d41fbe-7c62-4ee8-9454-b58e78dc83eb", "SuperAdmin", "SUPERADMIN" },
                    { "ba48dbc9-ee5b-48c0-8649-05860f3cfd0c", "0c4be6a3-c008-4bdf-9eef-3708fc510001", "Administrator", "ADMINISTRATOR" },
                    { "9d379802-3260-4c37-91e5-782002f18e4d", "3726a9ab-61fd-4f56-9b8e-bc673bcabc5a", "Driver", "DRIVER" },
                    { "f011f4df-ef48-40eb-9419-77164674d2d4", "8696f668-a878-4d21-aa69-21be504d0454", "Rider", "RIDER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d379802-3260-4c37-91e5-782002f18e4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9cd3c13-5f10-4e21-bade-52fb56dda8cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba48dbc9-ee5b-48c0-8649-05860f3cfd0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f011f4df-ef48-40eb-9419-77164674d2d4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOfDay",
                table: "EventTemplates",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b9ab474-6255-4268-8f7c-871bf48b5c0c", "4c791b5e-c21e-4219-8093-73690e8ee31d", "SuperAdmin", "SUPERADMIN" },
                    { "d87f4ceb-1532-4020-a80a-096271569ea9", "afb6afb9-0fba-4a21-bc3c-942005fbe733", "Administrator", "ADMINISTRATOR" },
                    { "3b52932c-ff02-4c3d-a214-b98c4199e7b0", "9449c44e-e10c-4cee-b580-f206f3973f58", "Driver", "DRIVER" },
                    { "54cb8096-0878-4c17-bb36-af28eb645f8a", "feb4aa5d-b972-4731-a384-46833455ca53", "Rider", "RIDER" }
                });
        }
    }
}
