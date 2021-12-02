using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class coordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateId",
                table: "UserCoordinates");

            migrationBuilder.DropTable(
                name: "EventTemplateBoundary");

            migrationBuilder.DropTable(
                name: "RouteDriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_UserCoordinates_CoordinateId",
                table: "UserCoordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

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
                name: "CoordinateId",
                table: "UserCoordinates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Coordinates");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "UserCoordinates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "UserCoordinates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CoordinateLatitude",
                table: "UserCoordinates",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CoordinateLongitude",
                table: "UserCoordinates",
                type: "float",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates",
                columns: new[] { "ApplicationUserId", "Latitude", "Longitude" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.CreateTable(
                name: "EventTemplateBoundaries",
                columns: table => new
                {
                    EventTemplateId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CoordinatesLatitude = table.Column<double>(type: "float", nullable: true),
                    CoordinatesLongitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTemplateBoundaries", x => new { x.EventTemplateId, x.Latitude, x.Longitude });
                    table.ForeignKey(
                        name: "FK_EventTemplateBoundaries_Coordinates_CoordinatesLatitude_CoordinatesLongitude",
                        columns: x => new { x.CoordinatesLatitude, x.CoordinatesLongitude },
                        principalTable: "Coordinates",
                        principalColumns: new[] { "Latitude", "Longitude" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventTemplateBoundaries_EventTemplates_EventTemplateId",
                        column: x => x.EventTemplateId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteDrivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDrivers", x => new { x.RouteId, x.DriverId });
                    table.ForeignKey(
                        name: "FK_RouteDrivers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteDrivers_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b092cea-c60a-4844-9a9e-462425591ca1", "c7c0f916-c67f-4478-a681-e5b3e94345b5", "SuperAdmin", "SUPERADMIN" },
                    { "59b8fb08-a70b-4919-b8c2-4f6e4016afea", "2b651955-da0e-408a-9540-a0567f7c97b5", "Administrator", "ADMINISTRATOR" },
                    { "7e4ff701-62e4-4f6c-8f6f-62f44e1f582a", "877cd9cc-ee62-430c-af48-82d64a9f0a9c", "Driver", "DRIVER" },
                    { "bfae3d6f-f75e-4d9b-a0ee-1380a2324a87", "19198d1c-876a-40f6-8d57-dac186fc440a", "Rider", "RIDER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCoordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates",
                columns: new[] { "CoordinateLatitude", "CoordinateLongitude" });

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplateBoundaries_CoordinatesLatitude_CoordinatesLongitude",
                table: "EventTemplateBoundaries",
                columns: new[] { "CoordinatesLatitude", "CoordinatesLongitude" });

            migrationBuilder.CreateIndex(
                name: "IX_RouteDrivers_DriverId",
                table: "RouteDrivers",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates",
                columns: new[] { "CoordinateLatitude", "CoordinateLongitude" },
                principalTable: "Coordinates",
                principalColumns: new[] { "Latitude", "Longitude" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates");

            migrationBuilder.DropTable(
                name: "EventTemplateBoundaries");

            migrationBuilder.DropTable(
                name: "RouteDrivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_UserCoordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59b8fb08-a70b-4919-b8c2-4f6e4016afea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e4ff701-62e4-4f6c-8f6f-62f44e1f582a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b092cea-c60a-4844-9a9e-462425591ca1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfae3d6f-f75e-4d9b-a0ee-1380a2324a87");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "UserCoordinates");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "UserCoordinates");

            migrationBuilder.DropColumn(
                name: "CoordinateLatitude",
                table: "UserCoordinates");

            migrationBuilder.DropColumn(
                name: "CoordinateLongitude",
                table: "UserCoordinates");

            migrationBuilder.AddColumn<int>(
                name: "CoordinateId",
                table: "UserCoordinates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Coordinates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates",
                columns: new[] { "ApplicationUserId", "CoordinateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EventTemplateBoundary",
                columns: table => new
                {
                    EventTemplateId = table.Column<int>(type: "int", nullable: false),
                    CoordinateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTemplateBoundary", x => new { x.EventTemplateId, x.CoordinateId });
                    table.ForeignKey(
                        name: "FK_EventTemplateBoundary_Coordinates_CoordinateId",
                        column: x => x.CoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTemplateBoundary_EventTemplates_EventTemplateId",
                        column: x => x.EventTemplateId,
                        principalTable: "EventTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteDriver",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDriver", x => new { x.RouteId, x.DriverId });
                    table.ForeignKey(
                        name: "FK_RouteDriver_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteDriver_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserCoordinates_CoordinateId",
                table: "UserCoordinates",
                column: "CoordinateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplateBoundary_CoordinateId",
                table: "EventTemplateBoundary",
                column: "CoordinateId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDriver_DriverId",
                table: "RouteDriver",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateId",
                table: "UserCoordinates",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
