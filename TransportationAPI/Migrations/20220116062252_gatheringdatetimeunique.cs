using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class Gatheringdatetimeunique : Migration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:Parameter should not span multiple lines", Justification = "Reviewed")]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53ee8ed1-0cbe-49b5-b672-5f3e88e5d412");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6367fd6d-951a-4f4e-a143-25c95d5440d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ac1a3ce-49c3-4c6c-bdf0-c6e66f4c81f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4bb86e6-fe9b-4cf7-b67d-b6cf06d443a5");

            migrationBuilder.RenameColumn(
                name: "GatheringDateTime",
                table: "Gatherings",
                newName: "DateAndTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a88284eb-5040-4b8d-bff9-6e3659a49791", "49cff4bb-dbf1-4958-beb0-fdab7e563554", "SuperAdmin", "SUPERADMIN" },
                    { "cac950f7-a841-4861-887e-3db5fd1bab1b", "0c7e554a-9c64-4cf9-bdd2-5d74d5b1d50f", "Administrator", "ADMINISTRATOR" },
                    { "09e7e10f-09e9-4475-89c1-2933afc87669", "e135d4b2-c120-4cb3-8835-3fa1aad204a3", "Driver", "DRIVER" },
                    { "b34133b6-e604-4b1a-bb71-0b26641f953c", "e1b4b6ff-7199-41dc-903c-e6909b269863", "User", "USER" },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gatherings_DateAndTime",
                table: "Gatherings",
                column: "DateAndTime",
                unique: true);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:Parameter should not span multiple lines", Justification = "Reviewed")]
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gatherings_DateAndTime",
                table: "Gatherings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09e7e10f-09e9-4475-89c1-2933afc87669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a88284eb-5040-4b8d-bff9-6e3659a49791");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b34133b6-e604-4b1a-bb71-0b26641f953c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac950f7-a841-4861-887e-3db5fd1bab1b");

            migrationBuilder.RenameColumn(
                name: "DateAndTime",
                table: "Gatherings",
                newName: "GatheringDateTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ac1a3ce-49c3-4c6c-bdf0-c6e66f4c81f0", "4a0eb050-ea40-4f3d-8306-cdd4604fc3a3", "SuperAdmin", "SUPERADMIN" },
                    { "53ee8ed1-0cbe-49b5-b672-5f3e88e5d412", "08cb3724-f2b9-45b7-8074-fc7e72703190", "Administrator", "ADMINISTRATOR" },
                    { "f4bb86e6-fe9b-4cf7-b67d-b6cf06d443a5", "483b4bb5-3d82-40d3-a045-9a93aa76661b", "Driver", "DRIVER" },
                    { "6367fd6d-951a-4f4e-a143-25c95d5440d7", "d0729f8d-81f7-4108-a09d-7f467f28ef6c", "User", "USER" },
                });
        }
    }
}
