using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportationAPI.Migrations
{
    public partial class CoordinateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTemplateBoundaries_Coordinates_CoordinatesLatitude_CoordinatesLongitude",
                table: "EventTemplateBoundaries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_EventTemplateBoundaries_CoordinatesLatitude_CoordinatesLongitude",
                table: "EventTemplateBoundaries");

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
                name: "CoordinatesLatitude",
                table: "EventTemplateBoundaries");

            migrationBuilder.DropColumn(
                name: "CoordinatesLongitude",
                table: "EventTemplateBoundaries");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "EventTemplateBoundaries",
                newName: "CoordinateLongitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "EventTemplateBoundaries",
                newName: "CoordinateLatitude");

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateLongitude",
                table: "UserCoordinates",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateLatitude",
                table: "UserCoordinates",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates",
                columns: new[] { "ApplicationUserId", "CoordinateLatitude", "CoordinateLongitude" });

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

            migrationBuilder.CreateIndex(
                name: "IX_EventTemplateBoundaries_CoordinateLatitude_CoordinateLongitude",
                table: "EventTemplateBoundaries",
                columns: new[] { "CoordinateLatitude", "CoordinateLongitude" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventTemplateBoundaries_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "EventTemplateBoundaries",
                columns: new[] { "CoordinateLatitude", "CoordinateLongitude" },
                principalTable: "Coordinates",
                principalColumns: new[] { "Latitude", "Longitude" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates",
                columns: new[] { "CoordinateLatitude", "CoordinateLongitude" },
                principalTable: "Coordinates",
                principalColumns: new[] { "Latitude", "Longitude" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTemplateBoundaries_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "EventTemplateBoundaries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates");

            migrationBuilder.DropIndex(
                name: "IX_EventTemplateBoundaries_CoordinateLatitude_CoordinateLongitude",
                table: "EventTemplateBoundaries");

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

            migrationBuilder.RenameColumn(
                name: "CoordinateLongitude",
                table: "EventTemplateBoundaries",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "CoordinateLatitude",
                table: "EventTemplateBoundaries",
                newName: "Latitude");

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateLongitude",
                table: "UserCoordinates",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateLatitude",
                table: "UserCoordinates",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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
                name: "CoordinatesLatitude",
                table: "EventTemplateBoundaries",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CoordinatesLongitude",
                table: "EventTemplateBoundaries",
                type: "float",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCoordinates",
                table: "UserCoordinates",
                columns: new[] { "ApplicationUserId", "Latitude", "Longitude" });

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
                name: "IX_EventTemplateBoundaries_CoordinatesLatitude_CoordinatesLongitude",
                table: "EventTemplateBoundaries",
                columns: new[] { "CoordinatesLatitude", "CoordinatesLongitude" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventTemplateBoundaries_Coordinates_CoordinatesLatitude_CoordinatesLongitude",
                table: "EventTemplateBoundaries",
                columns: new[] { "CoordinatesLatitude", "CoordinatesLongitude" },
                principalTable: "Coordinates",
                principalColumns: new[] { "Latitude", "Longitude" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoordinates_Coordinates_CoordinateLatitude_CoordinateLongitude",
                table: "UserCoordinates",
                columns: new[] { "CoordinateLatitude", "CoordinateLongitude" },
                principalTable: "Coordinates",
                principalColumns: new[] { "Latitude", "Longitude" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
