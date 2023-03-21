using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseConsole.Migrations
{
    /// <inheritdoc />
    public partial class Imtestingalot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Status_ErrandId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Errands_CustomerId",
                table: "Errands");

            migrationBuilder.CreateIndex(
                name: "IX_Status_ErrandId",
                table: "Status",
                column: "ErrandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Errands_CustomerId",
                table: "Errands",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Status_ErrandId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Errands_CustomerId",
                table: "Errands");

            migrationBuilder.CreateIndex(
                name: "IX_Status_ErrandId",
                table: "Status",
                column: "ErrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_CustomerId",
                table: "Errands",
                column: "CustomerId");
        }
    }
}
