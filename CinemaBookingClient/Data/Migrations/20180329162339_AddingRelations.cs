using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingClient.Data.Migrations
{
    public partial class AddingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order_Id",
                table: "Tickets",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "CinemaHall_Id",
                table: "Tickets",
                newName: "CinemaHallId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Cinema_Id",
                table: "Orders",
                newName: "CinemaId");

            migrationBuilder.RenameColumn(
                name: "Cinema_Id",
                table: "CinemaHalls",
                newName: "CinemaId");

            migrationBuilder.AlterColumn<string>(
                name: "Schema_Url",
                table: "CinemaHalls",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaHallId",
                table: "Tickets",
                column: "CinemaHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_CinemaId",
                table: "CinemaHalls",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CinemaHalls_CinemaHallId",
                table: "Tickets",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CinemaHalls_CinemaHallId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CinemaHallId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_CinemaId",
                table: "CinemaHalls");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Tickets",
                newName: "Order_Id");

            migrationBuilder.RenameColumn(
                name: "CinemaHallId",
                table: "Tickets",
                newName: "CinemaHall_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Orders",
                newName: "Cinema_Id");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "CinemaHalls",
                newName: "Cinema_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Schema_Url",
                table: "CinemaHalls",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
