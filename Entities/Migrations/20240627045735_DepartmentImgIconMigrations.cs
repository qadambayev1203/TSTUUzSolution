using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentImgIconMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departament_translations_20ts24tu_files_translations_20ts24~",
                table: "departament_translations_20ts24tu");

            migrationBuilder.AddColumn<int>(
                name: "img_icon_id",
                table: "departament_translations_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "img_icon_id",
                table: "departament_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9615), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9618), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9621), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9623), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9625), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9627), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9629), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9673), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9715), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9735), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9755), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9771), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9800), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9675), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9677), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9679), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9688), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9690), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9692), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9694), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9696), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9707), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9709), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9711), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9713), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9698), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9701), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9703), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9705), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9717), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9719), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9722), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9724), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9727), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9729), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9731), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9733), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9737), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9739), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9741), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9743), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9745), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9749), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9751), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9753), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9757), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9759), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9762), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9765), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9767), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9769), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9775), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9777), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9796), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9798), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9779), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9781), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9783), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9785), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9787), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9789), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9802), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9631), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9633), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9635), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9638), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9640), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 68,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9642), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9645), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9652), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9658), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9660), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9662), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9664), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9666), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9668), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                columns: new[] { "crated_at", "img_icon_id" },
                values: new object[] { new DateTime(2024, 6, 27, 4, 57, 34, 642, DateTimeKind.Utc).AddTicks(9671), null });

            migrationBuilder.CreateIndex(
                name: "IX_departament_translations_20ts24tu_img_icon_id",
                table: "departament_translations_20ts24tu",
                column: "img_icon_id");

            migrationBuilder.CreateIndex(
                name: "IX_departament_20ts24tu_img_icon_id",
                table: "departament_20ts24tu",
                column: "img_icon_id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_20ts24tu_files_20ts24tu_img_icon_id",
                table: "departament_20ts24tu",
                column: "img_icon_id",
                principalTable: "files_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_translations_20ts24tu_files_translations_20ts24~",
                table: "departament_translations_20ts24tu",
                column: "img_icon_id",
                principalTable: "files_translations_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_departament_translations_20ts24tu_files_translations_20ts2~1",
                table: "departament_translations_20ts24tu",
                column: "img_id",
                principalTable: "files_translations_20ts24tu",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departament_20ts24tu_files_20ts24tu_img_icon_id",
                table: "departament_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_departament_translations_20ts24tu_files_translations_20ts24~",
                table: "departament_translations_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_departament_translations_20ts24tu_files_translations_20ts2~1",
                table: "departament_translations_20ts24tu");

            migrationBuilder.DropIndex(
                name: "IX_departament_translations_20ts24tu_img_icon_id",
                table: "departament_translations_20ts24tu");

            migrationBuilder.DropIndex(
                name: "IX_departament_20ts24tu_img_icon_id",
                table: "departament_20ts24tu");

            migrationBuilder.DropColumn(
                name: "img_icon_id",
                table: "departament_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "img_icon_id",
                table: "departament_20ts24tu");

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3286));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3332));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3419));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3345));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3361));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3421));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3451));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3293));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3295));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3309));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 68,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3315));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3324));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3326));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 6, 21, 11, 46, 56, 520, DateTimeKind.Utc).AddTicks(3331));

            migrationBuilder.AddForeignKey(
                name: "FK_departament_translations_20ts24tu_files_translations_20ts24~",
                table: "departament_translations_20ts24tu",
                column: "img_id",
                principalTable: "files_translations_20ts24tu",
                principalColumn: "id");
        }
    }
}
