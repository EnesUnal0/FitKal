using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealAndAddFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<double>(
                name: "Carbs",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "EntryType",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GramAmount",
                table: "Meals",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Meals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaloriesPer100g = table.Column<double>(type: "float", nullable: false),
                    ProteinPer100g = table.Column<double>(type: "float", nullable: false),
                    CarbsPer100g = table.Column<double>(type: "float", nullable: false),
                    FatPer100g = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_FoodId",
                table: "Meals",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Meals_FoodId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "EntryType",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "GramAmount",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Meals");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
