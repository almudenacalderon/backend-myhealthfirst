using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class añadirCamposA_Meal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cena",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comida",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desayuno",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Media_mañana",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Merienda",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Otros",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post_entreno",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pre_entreno",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Comida",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Desayuno",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Media_mañana",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Merienda",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Otros",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Post_entreno",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Pre_entreno",
                table: "Meals");
        }
    }
}
