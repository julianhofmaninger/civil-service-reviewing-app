using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencies_Positions_PositionId",
                table: "Agencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Positions_PositionId",
                table: "Slots");

            migrationBuilder.DropIndex(
                name: "IX_Agencies_PositionId",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Agencies");

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "Slots",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Positions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AgencyPosition",
                columns: table => new
                {
                    AgenciesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyPosition", x => new { x.AgenciesId, x.PositionsId });
                    table.ForeignKey(
                        name: "FK_AgencyPosition_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgencyPosition_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_OwnerId",
                table: "Positions",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyPosition_PositionsId",
                table: "AgencyPosition",
                column: "PositionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Owners_OwnerId",
                table: "Positions",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Positions_PositionId",
                table: "Slots",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Owners_OwnerId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Positions_PositionId",
                table: "Slots");

            migrationBuilder.DropTable(
                name: "AgencyPosition");

            migrationBuilder.DropIndex(
                name: "IX_Positions_OwnerId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Positions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "Slots",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "Agencies",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_PositionId",
                table: "Agencies",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencies_Positions_PositionId",
                table: "Agencies",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Positions_PositionId",
                table: "Slots",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");
        }
    }
}
