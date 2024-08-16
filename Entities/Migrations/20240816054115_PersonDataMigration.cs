using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class PersonDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "blog_json",
                table: "persons_data_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "experience_json",
                table: "persons_data_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "portfolio_json",
                table: "persons_data_translations_20ts24tu");

            migrationBuilder.DropColumn(
                name: "blog_json",
                table: "persons_data_20ts24tu");

            migrationBuilder.DropColumn(
                name: "experience_json",
                table: "persons_data_20ts24tu");

            migrationBuilder.DropColumn(
                name: "portfolio_json",
                table: "persons_data_20ts24tu");

            migrationBuilder.RenameColumn(
                name: "scientific_activity_json",
                table: "persons_data_translations_20ts24tu",
                newName: "scientific_title");

            migrationBuilder.RenameColumn(
                name: "scientific_activity_json",
                table: "persons_data_20ts24tu",
                newName: "scientific_title");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "scientific_title",
                table: "persons_data_translations_20ts24tu",
                newName: "scientific_activity_json");

            migrationBuilder.RenameColumn(
                name: "scientific_title",
                table: "persons_data_20ts24tu",
                newName: "scientific_activity_json");

            migrationBuilder.AddColumn<string>(
                name: "blog_json",
                table: "persons_data_translations_20ts24tu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "experience_json",
                table: "persons_data_translations_20ts24tu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "portfolio_json",
                table: "persons_data_translations_20ts24tu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "blog_json",
                table: "persons_data_20ts24tu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "experience_json",
                table: "persons_data_20ts24tu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "portfolio_json",
                table: "persons_data_20ts24tu",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2718));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2699));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2715));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2741));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2743));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                column: "crated_at",
                value: new DateTime(2024, 8, 3, 4, 26, 25, 263, DateTimeKind.Utc).AddTicks(2648));
        }
    }
}
