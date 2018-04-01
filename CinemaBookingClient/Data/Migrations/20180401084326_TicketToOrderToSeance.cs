using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingClient.Data.Migrations
{
    public partial class TicketToOrderToSeance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CinemaHalls_CinemaHallId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CinemaHallId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaHallId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SeanceId",
                table: "Orders",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_CinemaHallId",
                table: "Seances",
                column: "CinemaHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Seances_SeanceId",
                table: "Orders",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_CinemaHalls_CinemaHallId",
                table: "Seances",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CinemaHalls_CinemaHallId",
                table: "Tickets",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Seances_SeanceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Seances_CinemaHalls_CinemaHallId",
                table: "Seances");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CinemaHalls_CinemaHallId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SeanceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Seances_CinemaHallId",
                table: "Seances");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaHallId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CinemaHallId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CinemaHalls_CinemaHallId",
                table: "Tickets",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
