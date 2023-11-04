using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreferenceId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPreferences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PreferenceId",
                table: "Accounts",
                column: "PreferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountPreferences_PreferenceId",
                table: "Accounts",
                column: "PreferenceId",
                principalTable: "AccountPreferences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountPreferences_PreferenceId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountPreferences");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PreferenceId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PreferenceId",
                table: "Accounts");
        }
    }
}
