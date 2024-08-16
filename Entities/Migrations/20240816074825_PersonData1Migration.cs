using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class PersonData1Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person_scientific_activity_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    since_when = table.Column<int>(type: "integer", nullable: true),
                    until_when = table.Column<int>(type: "integer", nullable: true),
                    whom = table.Column<string>(type: "text", nullable: true),
                    where = table.Column<string>(type: "text", nullable: true),
                    person_data_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_scientific_activity_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_scientific_activity_20ts24tu_persons_data_20ts24tu_p~",
                        column: x => x.person_data_id,
                        principalTable: "persons_data_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_person_scientific_activity_20ts24tu_statuses_20ts24tu_statu~",
                        column: x => x.status_id,
                        principalTable: "statuses_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "person_scientific_activity_translation_20ts24tu",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    since_when = table.Column<int>(type: "integer", nullable: true),
                    until_when = table.Column<int>(type: "integer", nullable: true),
                    whom = table.Column<string>(type: "text", nullable: true),
                    where = table.Column<string>(type: "text", nullable: true),
                    person_scientific_activity_id = table.Column<int>(type: "integer", nullable: true),
                    person_data_translation_id = table.Column<int>(type: "integer", nullable: true),
                    language_id = table.Column<int>(type: "integer", nullable: true),
                    status_translation_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_scientific_activity_translation_20ts24tu", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_scientific_activity_translation_20ts24tu_languages_2~",
                        column: x => x.language_id,
                        principalTable: "languages_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_person_scientific_activity_translation_20ts24tu_person_scie~",
                        column: x => x.person_scientific_activity_id,
                        principalTable: "person_scientific_activity_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_person_scientific_activity_translation_20ts24tu_persons_dat~",
                        column: x => x.person_data_translation_id,
                        principalTable: "persons_data_translations_20ts24tu",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_person_scientific_activity_translation_20ts24tu_statuses_tr~",
                        column: x => x.status_translation_id,
                        principalTable: "statuses_translations_20ts24tu",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 431, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 431, DateTimeKind.Utc).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 431, DateTimeKind.Utc).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 431, DateTimeKind.Utc).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 7, 48, 24, 430, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.CreateIndex(
                name: "IX_person_scientific_activity_20ts24tu_person_data_id",
                table: "person_scientific_activity_20ts24tu",
                column: "person_data_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_scientific_activity_20ts24tu_status_id",
                table: "person_scientific_activity_20ts24tu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_scientific_activity_translation_20ts24tu_language_id",
                table: "person_scientific_activity_translation_20ts24tu",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_scientific_activity_translation_20ts24tu_person_data~",
                table: "person_scientific_activity_translation_20ts24tu",
                column: "person_data_translation_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_scientific_activity_translation_20ts24tu_person_scie~",
                table: "person_scientific_activity_translation_20ts24tu",
                column: "person_scientific_activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_scientific_activity_translation_20ts24tu_status_tran~",
                table: "person_scientific_activity_translation_20ts24tu",
                column: "status_translation_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person_scientific_activity_translation_20ts24tu");

            migrationBuilder.DropTable(
                name: "person_scientific_activity_20ts24tu");

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 8, 16, 5, 41, 14, 334, DateTimeKind.Utc).AddTicks(1826));
        }
    }
}
