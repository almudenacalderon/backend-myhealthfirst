using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class ultimoscambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerTraining");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainerId",
                table: "Trainings",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Trainers_TrainerId",
                table: "Trainings",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Trainers_TrainerId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainerId",
                table: "Trainings");

            migrationBuilder.CreateTable(
                name: "TrainerTraining",
                columns: table => new
                {
                    TrainersId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTraining", x => new { x.TrainersId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainerTraining_Trainers_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerTraining_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTraining_TrainingId",
                table: "TrainerTraining",
                column: "TrainingId");
        }
    }
}
