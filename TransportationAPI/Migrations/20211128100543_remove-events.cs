using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class removeevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
