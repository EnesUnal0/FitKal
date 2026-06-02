using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfileFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ActivityLevel",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TargetWeight",
                table: "Users",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2769));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2882));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2898));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 3, 0, 11, 42, 673, DateTimeKind.Local).AddTicks(2899));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TargetWeight",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 28, 5, 27, 12, 69, DateTimeKind.Local).AddTicks(4763));
        }
    }
}
