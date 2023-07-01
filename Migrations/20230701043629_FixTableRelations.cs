using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adstaskhub_api.Migrations
{
    /// <inheritdoc />
    public partial class FixTableRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_classes_class_id",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_classes_class_id",
                table: "tasks",
                column: "class_id",
                principalTable: "classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_classes_class_id",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_classes_class_id",
                table: "tasks",
                column: "class_id",
                principalTable: "classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
