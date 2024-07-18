using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class twoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appeal_to_employee_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    subject = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appeal_to_employee_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_appeal_to_employee_20ts24tu_statuses_20ts24tu_status_id",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeal_to_employee_20ts24tu_users_20ts24tu_user_id",
                        column: x => x.user_id,
                        principalTable: "users_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "appeal_to_employee_translation_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    subject = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appeal_to_employee_translation_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_appeal_to_employee_translation_20ts24tu_languages_20ts24tu_~",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeal_to_employee_translation_20ts24tu_statuses_translatio~",
                        column: x => x.status_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appeal_to_employee_translation_20ts24tu_users_20ts24tu_user~",
                        column: x => x.user_id,
                        principalTable: "users_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(174));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(188));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(194));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 7, 18, 5, 45, 34, 429, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.CreateIndex(
                name: "IX_appeal_to_employee_20ts24tu_status_id",
                table: "appeal_to_employee_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeal_to_employee_20ts24tu_user_id",
                table: "appeal_to_employee_20ts24tu",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeal_to_employee_translation_20ts24tu_language_id",
                table: "appeal_to_employee_translation_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeal_to_employee_translation_20ts24tu_status_id",
                table: "appeal_to_employee_translation_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_appeal_to_employee_translation_20ts24tu_user_id",
                table: "appeal_to_employee_translation_20ts24tu",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appeal_to_employee_20ts24tu");

            migrationBuilder.DropTable(
                name: "appeal_to_employee_translation_20ts24tu");

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2499));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2565));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2637));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 7, 4, 7, 19, 57, 0, DateTimeKind.Utc).AddTicks(2545));
        }
    }
}
