using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Obermind.Operation.Data.Access.Migrations
{
    public partial class UserIdInPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PurchaseOrder",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ItemId",
                keyValue: "2083E168-9B48-4BA9-ABA0-B9252CF6DAD5",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 9, 13, 45, 8, 812, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ItemId",
                keyValue: "A71C3887-3C19-4695-8249-7C7F1C6A8DA4",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 9, 13, 45, 8, 810, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ItemId",
                keyValue: "E3F1140C-BA46-437F-9234-9CE9D16DA2DF",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 9, 13, 45, 8, 812, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "PurchaseOrder",
                keyColumn: "POId",
                keyValue: "491E44F7-12DA-4470-95BA-D6B01ACBB45A",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 9, 13, 45, 8, 821, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "PurchaseOrder",
                keyColumn: "POId",
                keyValue: "AD8D7916-EE72-4438-9C5E-90B03EC98857",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 9, 13, 45, 8, 821, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "49aaee27-f4a5-4db5-95b5-8f7b1550a5bd",
                column: "Password",
                value: "$2a$11$kn7vLbQZ5Wg7AwXJUmJpI.ZZi7ZE8RUUb0PQIGJr0BiDjNJBDpF5S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e8e5d832-765c-45a8-9650-c16f48f84d1b",
                column: "Password",
                value: "$2a$11$CWgoGp2KcC/x8VwsglMLgeM6qH7NHtR1WMLdZHJc1PTP3fb7BqbGu");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_UserId",
                table: "PurchaseOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Users_UserId",
                table: "PurchaseOrder",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Users_UserId",
                table: "PurchaseOrder");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrder_UserId",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PurchaseOrder");

            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ItemId",
                keyValue: "2083E168-9B48-4BA9-ABA0-B9252CF6DAD5",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 5, 0, 59, 26, 128, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ItemId",
                keyValue: "A71C3887-3C19-4695-8249-7C7F1C6A8DA4",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 5, 0, 59, 26, 126, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ItemId",
                keyValue: "E3F1140C-BA46-437F-9234-9CE9D16DA2DF",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 5, 0, 59, 26, 128, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "PurchaseOrder",
                keyColumn: "POId",
                keyValue: "491E44F7-12DA-4470-95BA-D6B01ACBB45A",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 5, 0, 59, 26, 136, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "PurchaseOrder",
                keyColumn: "POId",
                keyValue: "AD8D7916-EE72-4438-9C5E-90B03EC98857",
                column: "CreatedAt",
                value: new DateTime(2022, 1, 5, 0, 59, 26, 137, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "49aaee27-f4a5-4db5-95b5-8f7b1550a5bd",
                column: "Password",
                value: "$2a$11$5bvNNs.8fUBTd6XYQMXQXeUhMJgYfuON5u/QgAgnNmRk8Zj71/SXW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e8e5d832-765c-45a8-9650-c16f48f84d1b",
                column: "Password",
                value: "$2a$11$JUn0iZxm5G23SnOUQSbaIeLrYHxnwrwppRzYaKig3LizUCGvlZpT.");
        }
    }
}
