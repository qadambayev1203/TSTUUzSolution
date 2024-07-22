using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hemis_id",
                table: "departament_20ts24tu",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1761), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1765), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1768), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1771), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1774), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1777), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1780), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1838), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1888), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1913), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1940), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1967), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1996), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1841), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1844), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1847), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1849), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1852), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1855), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1858), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1860), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1877), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1879), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1882), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1885), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1863), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1866), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1869), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1874), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1891), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1893), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1896), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1899), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1902), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1905), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1908), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1911), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1916), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1919), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1922), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 41,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1925), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 42,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1927), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 43,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1930), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 44,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1933), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 45,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1936), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 46,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1943), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 47,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1946), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 48,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1948), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 49,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1951), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 50,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1954), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 51,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1956), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 52,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1969), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 53,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1972), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 54,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1991), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 55,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1994), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 56,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1975), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 57,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1977), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 58,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1980), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 59,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1983), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 60,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1985), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 61,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1988), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 62,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1999), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 63,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1783), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 64,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1785), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 65,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1788), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 66,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1791), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 67,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1794), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 69,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1797), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 70,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1799), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 71,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1807), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 72,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1816), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 73,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1818), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 74,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1821), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 75,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1824), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 76,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1833), null });

            migrationBuilder.UpdateData(
                table: "departament_20ts24tu",
                keyColumn: "id",
                keyValue: 77,
                columns: new[] { "crated_at", "hemis_id" },
                values: new object[] { new DateTime(2024, 7, 22, 15, 47, 37, 938, DateTimeKind.Utc).AddTicks(1836), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hemis_id",
                table: "departament_20ts24tu");

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
        }
    }
}
