using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_two",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_one",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "fio_",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "appeal",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "addres",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_two",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_one",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "fio_",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "appeals_to_rectors_20ts24tu",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "appeals_to_rectors_20ts24tu",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "appeal",
                table: "appeals_to_rectors_20ts24tu",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "addres",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7673));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 7, 26, 17, 5, 55, 70, DateTimeKind.Utc).AddTicks(7670));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_two",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_one",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fio_",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "appeal",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "addres",
                table: "appeals_to_rectors_translations_20ts24tu",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_two",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telephone_number_one",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fio_",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "appeals_to_rectors_20ts24tu",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "appeals_to_rectors_20ts24tu",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "appeal",
                table: "appeals_to_rectors_20ts24tu",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "addres",
                table: "appeals_to_rectors_20ts24tu",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

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
    }
}
