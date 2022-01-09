using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Obermind.Operation.Data.Access.Migrations
{
    public partial class CreateObermindDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    POId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.POId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    ItemId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    POId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ListItem_PurchaseOrder_POId",
                        column: x => x.POId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrder",
                columns: new[] { "POId", "Amount", "CreatedAt", "IsDeleted", "Name", "OrderBy", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "491E44F7-12DA-4470-95BA-D6B01ACBB45A", 1200m, new DateTime(2022, 1, 5, 0, 59, 26, 136, DateTimeKind.Local).AddTicks(9195), false, "D1 - Purchase Order", 1, "SUBMITTED", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AD8D7916-EE72-4438-9C5E-90B03EC98857", 200m, new DateTime(2022, 1, 5, 0, 59, 26, 137, DateTimeKind.Local).AddTicks(361), false, "D2 - Purchase Order", 2, "DRAFT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1549C3D8-6511-41AA-A82E-8DC75FC7E761", "Admin" },
                    { "B2A00501-BF6B-4C7F-A789-5986E769F4FB", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { "e8e5d832-765c-45a8-9650-c16f48f84d1b", "taimurad@hotmail.com", "Taimoor", false, "Adil", "$2a$11$JUn0iZxm5G23SnOUQSbaIeLrYHxnwrwppRzYaKig3LizUCGvlZpT.", "tab" },
                    { "49aaee27-f4a5-4db5-95b5-8f7b1550a5bd", "test@mail.com", "Obermind", false, "Purchase", "$2a$11$5bvNNs.8fUBTd6XYQMXQXeUhMJgYfuON5u/QgAgnNmRk8Zj71/SXW", "official" }
                });

            migrationBuilder.InsertData(
                table: "ListItem",
                columns: new[] { "ItemId", "Amount", "CreatedAt", "IsDeleted", "Name", "POId", "UpdatedAt" },
                values: new object[,]
                {
                    { "A71C3887-3C19-4695-8249-7C7F1C6A8DA4", 1000m, new DateTime(2022, 1, 5, 0, 59, 26, 126, DateTimeKind.Local).AddTicks(9108), false, "D1 - List Item", "491E44F7-12DA-4470-95BA-D6B01ACBB45A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "E3F1140C-BA46-437F-9234-9CE9D16DA2DF", 200m, new DateTime(2022, 1, 5, 0, 59, 26, 128, DateTimeKind.Local).AddTicks(498), false, "D2 - List Item", "491E44F7-12DA-4470-95BA-D6B01ACBB45A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2083E168-9B48-4BA9-ABA0-B9252CF6DAD5", 200m, new DateTime(2022, 1, 5, 0, 59, 26, 128, DateTimeKind.Local).AddTicks(554), false, "D3 - List Item", "AD8D7916-EE72-4438-9C5E-90B03EC98857", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "F48E075B-C74D-478A-8136-A38B09E7CC63", "1549C3D8-6511-41AA-A82E-8DC75FC7E761", "e8e5d832-765c-45a8-9650-c16f48f84d1b" },
                    { "212CF5EF-F517-46D8-9AD5-339CEE387C8A", "1549C3D8-6511-41AA-A82E-8DC75FC7E761", "49aaee27-f4a5-4db5-95b5-8f7b1550a5bd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_POId",
                table: "ListItem",
                column: "POId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
