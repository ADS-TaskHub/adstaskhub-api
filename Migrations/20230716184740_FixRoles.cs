using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adstaskhub_api.Migrations
{
    /// <inheritdoc />
    public partial class FixRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "role_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 2L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValue: 3L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "role_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 3L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValue: 2L);
        }
    }
}
