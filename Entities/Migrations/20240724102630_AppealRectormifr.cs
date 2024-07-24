using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class AppealRectormifr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_statuses_20ts24tu_status_id",
                table: "appeals_to_rectors_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_appeals_to_rectors_translations_20ts24tu_statuses_translati~",
                table: "appeals_to_rectors_translations_20ts24tu");

            migrationBuilder.DropIndex(
                name: "IX_appeals_to_rectors_translations_20ts24tu_status_translation~",
                table: "appeals_to_rectors_translations_20ts24tu");

            migrationBuilder.DropIndex(
                name: "IX_appeals_to_rectors_20ts24tu_status_id",
                table: "appeals_to_rectors_20ts24tu");

            migrationBuilder.DropColumn(
                name: "status_translation_id",
                table: "appeals_to_rectors_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "appeals_to_rectors_20ts24tu");

            migrationBuilder.AddColumn<bool>(
                name: "confirm",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "confirm",
                table: "appeals_to_rectors_20ts24tu",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(604));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(643));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(645));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(659));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(699));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(712));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(727));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 7, 24, 10, 26, 28, 935, DateTimeKind.Utc).AddTicks(640));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirm",
                table: "appeals_to_rectors_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "confirm",
                table: "appeals_to_rectors_20ts24tu");

            migrationBuilder.AddColumn<int>(
                name: "status_translation_id",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status_id",
                table: "appeals_to_rectors_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1836));

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_translations_20ts24tu_status_translation~",
                table: "appeals_to_rectors_translations_20ts24tu",
                column: "status_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeals_to_rectors_20ts24tu_status_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_20ts24tu_statuses_20ts24tu_status_id",
                table: "appeals_to_rectors_20ts24tu",
                column: "status_id",
                principalTable: "statuses_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appeals_to_rectors_translations_20ts24tu_statuses_translati~",
                table: "appeals_to_rectors_translations_20ts24tu",
                column: "status_translation_id",
                principalTable: "statuses_translations_20ts24tu",
                principalColumn: "id");
        }
    }
}
