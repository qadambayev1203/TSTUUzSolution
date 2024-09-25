using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class migration111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "confirmed",
                table: "person_scientific_activity_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "confirmed",
                table: "person_portfolio_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "confirmed",
                table: "person_experience_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "confirmed",
                table: "person_blog_20ts24tu",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6797));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 9, 36, 17, 292, DateTimeKind.Utc).AddTicks(6691));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmed",
                table: "person_scientific_activity_20ts24tu");

            migrationBuilder.DropColumn(
                name: "confirmed",
                table: "person_portfolio_20ts24tu");

            migrationBuilder.DropColumn(
                name: "confirmed",
                table: "person_experience_20ts24tu");

            migrationBuilder.DropColumn(
                name: "confirmed",
                table: "person_blog_20ts24tu");

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 9, 25, 4, 48, 32, 165, DateTimeKind.Utc).AddTicks(4123));
        }
    }
}
