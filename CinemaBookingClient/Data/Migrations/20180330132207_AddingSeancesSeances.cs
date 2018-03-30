using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingClient.Data.Migrations
{
    public partial class AddingSeancesSeances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Orders",
                newName: "CinemaHallId");

            migrationBuilder.AlterColumn<int>(
                name: "AreaNumber",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeanceId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cinemas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CinemaHallId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SeanceId",
                table: "Orders",
                column: "SeanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Seances_SeanceId",
                table: "Orders",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Seances_SeanceId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SeanceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SeanceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cinemas");

            migrationBuilder.RenameColumn(
                name: "CinemaHallId",
                table: "Orders",
                newName: "CinemaId");

            migrationBuilder.AlterColumn<string>(
                name: "AreaNumber",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
