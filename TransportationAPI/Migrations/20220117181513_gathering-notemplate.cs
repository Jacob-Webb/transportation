using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class gatheringnotemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gatherings_GatheringTemplates_TemplateId",
                table: "Gatherings");

            migrationBuilder.DropIndex(
                name: "IX_Gatherings_TemplateId",
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

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Gatherings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f7fb27c-04c6-41c7-9b65-91292788b8d1", "8bd45a16-8c85-46c8-97ab-2f8b1a431ba9", "SuperAdmin", "SUPERADMIN" },
                    { "ae86bbae-0f2d-4b04-8901-5f01cce2c051", "5dfa24c6-8610-4c4b-93fd-b35a3336f286", "Administrator", "ADMINISTRATOR" },
                    { "fad873d5-92b1-441d-9d47-885960f43632", "7dc5ff63-a7d9-429c-8682-2be9e47a3f7e", "Driver", "DRIVER" },
                    { "8834452b-1803-4f41-b607-61135a243f03", "5ce6d84b-f2bc-4469-8f89-ad29893d7661", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f7fb27c-04c6-41c7-9b65-91292788b8d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8834452b-1803-4f41-b607-61135a243f03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae86bbae-0f2d-4b04-8901-5f01cce2c051");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad873d5-92b1-441d-9d47-885960f43632");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Gatherings",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a88284eb-5040-4b8d-bff9-6e3659a49791", "49cff4bb-dbf1-4958-beb0-fdab7e563554", "SuperAdmin", "SUPERADMIN" },
                    { "cac950f7-a841-4861-887e-3db5fd1bab1b", "0c7e554a-9c64-4cf9-bdd2-5d74d5b1d50f", "Administrator", "ADMINISTRATOR" },
                    { "09e7e10f-09e9-4475-89c1-2933afc87669", "e135d4b2-c120-4cb3-8835-3fa1aad204a3", "Driver", "DRIVER" },
                    { "b34133b6-e604-4b1a-bb71-0b26641f953c", "e1b4b6ff-7199-41dc-903c-e6909b269863", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gatherings_TemplateId",
                table: "Gatherings",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gatherings_GatheringTemplates_TemplateId",
                table: "Gatherings",
                column: "TemplateId",
                principalTable: "GatheringTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
