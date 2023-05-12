using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaTemplate.Migrations
{
    /// <inheritdoc />
    public partial class CreatePersonsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Positions_PositionId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Person_PositionId",
                table: "Persons",
                newName: "IX_Persons_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Positions_PositionId",
                table: "Persons",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Positions_PositionId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PositionId",
                table: "Person",
                newName: "IX_Person_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Positions_PositionId",
                table: "Person",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
