using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adstaskhub_api.Migrations
{
    /// <inheritdoc />
    public partial class FixMappingTaskAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_assignments_tasks_TaskId",
                table: "tasks_assignments");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "tasks_assignments",
                newName: "task_id");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_assignments_TaskId",
                table: "tasks_assignments",
                newName: "IX_tasks_assignments_task_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_assignments_tasks_task_id",
                table: "tasks_assignments",
                column: "task_id",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_assignments_tasks_task_id",
                table: "tasks_assignments");

            migrationBuilder.RenameColumn(
                name: "task_id",
                table: "tasks_assignments",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_assignments_task_id",
                table: "tasks_assignments",
                newName: "IX_tasks_assignments_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_assignments_tasks_TaskId",
                table: "tasks_assignments",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
