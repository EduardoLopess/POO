using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apinet06.Migrations
{
    public partial class clientAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cobranca_ClientId",
                table: "Cobranca");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_ClientId",
                table: "Cobranca",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cobranca_ClientId",
                table: "Cobranca");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_ClientId",
                table: "Cobranca",
                column: "ClientId");
        }
    }
}
