using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SourceAuthId",
                table: "Observers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SourceAuth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceAuth", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observers_SourceAuthId",
                table: "Observers",
                column: "SourceAuthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observers_SourceAuth_SourceAuthId",
                table: "Observers",
                column: "SourceAuthId",
                principalTable: "SourceAuth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observers_SourceAuth_SourceAuthId",
                table: "Observers");

            migrationBuilder.DropTable(
                name: "SourceAuth");

            migrationBuilder.DropIndex(
                name: "IX_Observers_SourceAuthId",
                table: "Observers");

            migrationBuilder.DropColumn(
                name: "SourceAuthId",
                table: "Observers");
        }
    }
}
