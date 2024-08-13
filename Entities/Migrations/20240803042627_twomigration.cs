using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations;

/// <inheritdoc />
public partial class twomigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "one_indicator",
            table: "document_teacher_110_20ts24tu");

        migrationBuilder.DropColumn(
            name: "two_indicator",
            table: "document_teacher_110_20ts24tu");

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

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "one_indicator",
            table: "document_teacher_110_20ts24tu",
            type: "boolean",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "two_indicator",
            table: "document_teacher_110_20ts24tu",
            type: "boolean",
            nullable: true);

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 1,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4236));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 2,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4242));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 3,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4244));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 4,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4245));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 5,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4247));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 6,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4249));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 7,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4250));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 8,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4283));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 9,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4316));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 10,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4338));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 11,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4354));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 12,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4365));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 13,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4383));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 14,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4286));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 15,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4288));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 16,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4289));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 17,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4291));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 18,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4292));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 19,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4294));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 20,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4296));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 21,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4297));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 22,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4310));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 23,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4311));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 24,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4313));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 25,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4314));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 26,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4299));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 27,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4301));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 28,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4302));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 29,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4304));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 30,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4318));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 31,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4319));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 32,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4321));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 33,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4323));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 34,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4331));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 35,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4333));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 36,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4335));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 37,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4337));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 38,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4340));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 39,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4342));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 40,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4343));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 41,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4345));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 42,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4346));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 43,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4348));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 44,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4350));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 45,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4351));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 46,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4356));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 47,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4357));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 48,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4359));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 49,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4360));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 50,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4362));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 51,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4364));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 52,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4367));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 53,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4369));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 54,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4380));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 55,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4381));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 56,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4370));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 57,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4372));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 58,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4373));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 59,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4375));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 60,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4377));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 61,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4378));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 62,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4385));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 63,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4252));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 64,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4254));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 65,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4255));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 66,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4257));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 67,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4260));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 69,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4261));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 70,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4263));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 71,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4269));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 72,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4274));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 73,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4275));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 74,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4277));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 75,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4279));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 76,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4280));

        migrationBuilder.UpdateData(
            table: "departament_20ts24tu",
            keyColumn: "id",
            keyValue: 77,
            column: "crated_at",
            value: new DateTime(2024, 7, 30, 14, 14, 8, 85, DateTimeKind.Utc).AddTicks(4282));
    }
}
