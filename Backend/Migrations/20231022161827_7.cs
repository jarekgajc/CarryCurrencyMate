using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observers_SourceAuth_SourceAuthId",
                table: "Observers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SourceAuth",
                table: "SourceAuth");

            migrationBuilder.RenameTable(
                name: "SourceAuth",
                newName: "SourceAuths");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SourceAuths",
                table: "SourceAuths",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observers_SourceAuths_SourceAuthId",
                table: "Observers",
                column: "SourceAuthId",
                principalTable: "SourceAuths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observers_SourceAuths_SourceAuthId",
                table: "Observers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SourceAuths",
                table: "SourceAuths");

            migrationBuilder.RenameTable(
                name: "SourceAuths",
                newName: "SourceAuth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SourceAuth",
                table: "SourceAuth",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observers_SourceAuth_SourceAuthId",
                table: "Observers",
                column: "SourceAuthId",
                principalTable: "SourceAuth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
