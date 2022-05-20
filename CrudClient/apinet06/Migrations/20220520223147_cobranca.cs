using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apinet06.Migrations
{
    public partial class cobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobranca_Client_ClientId",
                table: "Cobranca");

            migrationBuilder.DropIndex(
                name: "IX_Cobranca_ClientId",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Cobranca");

            migrationBuilder.AddColumn<int>(
                name: "cobrancaId",
                table: "Client",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_cobrancaId",
                table: "Client",
                column: "cobrancaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Cobranca_cobrancaId",
                table: "Client",
                column: "cobrancaId",
                principalTable: "Cobranca",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Cobranca_cobrancaId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_cobrancaId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "cobrancaId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Cobranca",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_ClientId",
                table: "Cobranca",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobranca_Client_ClientId",
                table: "Cobranca",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
