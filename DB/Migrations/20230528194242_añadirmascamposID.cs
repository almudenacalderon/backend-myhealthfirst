using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class añadirmascamposID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Nutricionists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "Nutricionists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Diets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NutricionistId",
                table: "Diets",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Nutricionists");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "Nutricionists");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "NutricionistId",
                table: "Diets");
        }
    }
}
