using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adstaskhub_api.Migrations
{
    /// <inheritdoc />
    public partial class FixEntityUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "tasks_assignments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "tasks_assignments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "tasks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "tasks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "roles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "roles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "periods",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "periods",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "classes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "classes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "users");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "tasks_assignments");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "tasks_assignments");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "periods");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "periods");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "classes");
        }
    }
}
