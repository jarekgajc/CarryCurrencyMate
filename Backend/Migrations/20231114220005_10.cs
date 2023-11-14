using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Currency",
                table: "AccountPreferences",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Exchangers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<int>(type: "int", nullable: false),
                    SourceAuthId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchangers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchangers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exchangers_SourceAuths_SourceAuthId",
                        column: x => x.SourceAuthId,
                        principalTable: "SourceAuths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exchangers_AccountId",
                table: "Exchangers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchangers_SourceAuthId",
                table: "Exchangers",
                column: "SourceAuthId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exchangers");

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "AccountPreferences",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
