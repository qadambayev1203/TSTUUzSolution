using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class newMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doucument_teacher_110_20ts24tu_statuses_20ts24tu_status_id",
                table: "doucument_teacher_110_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_doucument_teacher_110_20~",
                table: "doucument_teacher_110_set_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_files_20ts24tu_file_id",
                table: "doucument_teacher_110_set_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_persons_20ts24tu_person_~",
                table: "doucument_teacher_110_set_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_statuses_20ts24tu_status~",
                table: "doucument_teacher_110_set_20ts24tu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doucument_teacher_110_set_20ts24tu",
                table: "doucument_teacher_110_set_20ts24tu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doucument_teacher_110_20ts24tu",
                table: "doucument_teacher_110_20ts24tu");

            migrationBuilder.RenameTable(
                name: "doucument_teacher_110_set_20ts24tu",
                newName: "document_teacher_110_set_20ts24tu");

            migrationBuilder.RenameTable(
                name: "doucument_teacher_110_20ts24tu",
                newName: "document_teacher_110_20ts24tu");

            migrationBuilder.RenameIndex(
                name: "IX_doucument_teacher_110_set_20ts24tu_status_id",
                table: "document_teacher_110_set_20ts24tu",
                newName: "IX_document_teacher_110_set_20ts24tu_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_doucument_teacher_110_set_20ts24tu_person_id",
                table: "document_teacher_110_set_20ts24tu",
                newName: "IX_document_teacher_110_set_20ts24tu_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_doucument_teacher_110_set_20ts24tu_file_id",
                table: "document_teacher_110_set_20ts24tu",
                newName: "IX_document_teacher_110_set_20ts24tu_file_id");

            migrationBuilder.RenameIndex(
                name: "IX_doucument_teacher_110_set_20ts24tu_document_id",
                table: "document_teacher_110_set_20ts24tu",
                newName: "IX_document_teacher_110_set_20ts24tu_document_id");

            migrationBuilder.RenameIndex(
                name: "IX_doucument_teacher_110_20ts24tu_status_id",
                table: "document_teacher_110_20ts24tu",
                newName: "IX_document_teacher_110_20ts24tu_status_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_document_teacher_110_set_20ts24tu",
                table: "document_teacher_110_set_20ts24tu",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_document_teacher_110_20ts24tu",
                table: "document_teacher_110_20ts24tu",
                column: "id");

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9909));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9921));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 32, 42, 955, DateTimeKind.Utc).AddTicks(9886));

            migrationBuilder.AddForeignKey(
                name: "FK_document_teacher_110_20ts24tu_statuses_20ts24tu_status_id",
                table: "document_teacher_110_20ts24tu",
                column: "status_id",
                principalTable: "statuses_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_document_teacher_110_20ts~",
                table: "document_teacher_110_set_20ts24tu",
                column: "document_id",
                principalTable: "document_teacher_110_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_files_20ts24tu_file_id",
                table: "document_teacher_110_set_20ts24tu",
                column: "file_id",
                principalTable: "files_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_persons_20ts24tu_person_id",
                table: "document_teacher_110_set_20ts24tu",
                column: "person_id",
                principalTable: "persons_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_statuses_20ts24tu_status_~",
                table: "document_teacher_110_set_20ts24tu",
                column: "status_id",
                principalTable: "statuses_20ts24tu",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_document_teacher_110_20ts24tu_statuses_20ts24tu_status_id",
                table: "document_teacher_110_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_document_teacher_110_20ts~",
                table: "document_teacher_110_set_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_files_20ts24tu_file_id",
                table: "document_teacher_110_set_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_persons_20ts24tu_person_id",
                table: "document_teacher_110_set_20ts24tu");

            migrationBuilder.DropForeignKey(
                name: "FK_document_teacher_110_set_20ts24tu_statuses_20ts24tu_status_~",
                table: "document_teacher_110_set_20ts24tu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_document_teacher_110_set_20ts24tu",
                table: "document_teacher_110_set_20ts24tu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_document_teacher_110_20ts24tu",
                table: "document_teacher_110_20ts24tu");

            migrationBuilder.RenameTable(
                name: "document_teacher_110_set_20ts24tu",
                newName: "doucument_teacher_110_set_20ts24tu");

            migrationBuilder.RenameTable(
                name: "document_teacher_110_20ts24tu",
                newName: "doucument_teacher_110_20ts24tu");

            migrationBuilder.RenameIndex(
                name: "IX_document_teacher_110_set_20ts24tu_status_id",
                table: "doucument_teacher_110_set_20ts24tu",
                newName: "IX_doucument_teacher_110_set_20ts24tu_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_document_teacher_110_set_20ts24tu_person_id",
                table: "doucument_teacher_110_set_20ts24tu",
                newName: "IX_doucument_teacher_110_set_20ts24tu_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_document_teacher_110_set_20ts24tu_file_id",
                table: "doucument_teacher_110_set_20ts24tu",
                newName: "IX_doucument_teacher_110_set_20ts24tu_file_id");

            migrationBuilder.RenameIndex(
                name: "IX_document_teacher_110_set_20ts24tu_document_id",
                table: "doucument_teacher_110_set_20ts24tu",
                newName: "IX_doucument_teacher_110_set_20ts24tu_document_id");

            migrationBuilder.RenameIndex(
                name: "IX_document_teacher_110_20ts24tu_status_id",
                table: "doucument_teacher_110_20ts24tu",
                newName: "IX_doucument_teacher_110_20ts24tu_status_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_doucument_teacher_110_set_20ts24tu",
                table: "doucument_teacher_110_set_20ts24tu",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_doucument_teacher_110_20ts24tu",
                table: "doucument_teacher_110_20ts24tu",
                column: "id");

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 7, 30, 5, 25, 20, 15, DateTimeKind.Utc).AddTicks(7481));

            migrationBuilder.AddForeignKey(
                name: "FK_doucument_teacher_110_20ts24tu_statuses_20ts24tu_status_id",
                table: "doucument_teacher_110_20ts24tu",
                column: "status_id",
                principalTable: "statuses_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_doucument_teacher_110_20~",
                table: "doucument_teacher_110_set_20ts24tu",
                column: "document_id",
                principalTable: "doucument_teacher_110_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_files_20ts24tu_file_id",
                table: "doucument_teacher_110_set_20ts24tu",
                column: "file_id",
                principalTable: "files_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_persons_20ts24tu_person_~",
                table: "doucument_teacher_110_set_20ts24tu",
                column: "person_id",
                principalTable: "persons_20ts24tu",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_doucument_teacher_110_set_20ts24tu_statuses_20ts24tu_status~",
                table: "doucument_teacher_110_set_20ts24tu",
                column: "status_id",
                principalTable: "statuses_20ts24tu",
                principalColumn: "id");
        }
    }
}
