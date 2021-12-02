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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
