using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CinemaBookingClient.Data.Migrations
{
    public partial class FKAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AspNetUsers_Id",
                table: "Customers",
                newName: "AspNetUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AspNetUsersId",
                table: "Customers",
                newName: "AspNetUsers_Id");
        }
    }
}
