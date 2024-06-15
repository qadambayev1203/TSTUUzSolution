using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class twoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "event_date",
                table: "blogs_translations_20ts24tu",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "event_end_date",
                table: "blogs_translations_20ts24tu",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "event_date",
                table: "blogs_20ts24tu",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "event_end_date",
                table: "blogs_20ts24tu",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1515));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1522));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1538));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 68,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 6, 15, 16, 40, 55, 545, DateTimeKind.Utc).AddTicks(1444));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "event_date",
                table: "blogs_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "event_end_date",
                table: "blogs_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "event_date",
                table: "blogs_20ts24tu");

            migrationBuilder.DropColumn(
                name: "event_end_date",
                table: "blogs_20ts24tu");

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8527));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8531));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8611));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 68,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 6, 13, 6, 25, 40, 120, DateTimeKind.Utc).AddTicks(8517));
        }
    }
}
