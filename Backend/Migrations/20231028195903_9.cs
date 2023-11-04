using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountPreferences_PreferenceId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PreferenceId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PreferenceId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AccountPreferences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountPreferences_AccountId",
                table: "AccountPreferences",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPreferences_Accounts_AccountId",
                table: "AccountPreferences",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountPreferences_Accounts_AccountId",
                table: "AccountPreferences");

            migrationBuilder.DropIndex(
                name: "IX_AccountPreferences_AccountId",
                table: "AccountPreferences");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AccountPreferences");

            migrationBuilder.AddColumn<int>(
                name: "PreferenceId",
                table: "Accounts",
                type: "int",
                nullable: true);

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
    }
}
