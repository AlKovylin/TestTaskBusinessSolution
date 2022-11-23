using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskBusinessSolution.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Петротех" },
                    { 2, "Союзметалл" },
                    { 3, "Вестмет" },
                    { 4, "Севзапметалл" },
                    { 5, "Петроснаб" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Number", "ProviderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 18, 12, 10, 29, 396, DateTimeKind.Local).AddTicks(325), "TT852431", 1 },
                    { 2, new DateTime(2022, 10, 16, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(293), "TT852432", 1 },
                    { 3, new DateTime(2022, 9, 23, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(306), "TT852433", 1 },
                    { 4, new DateTime(2022, 11, 20, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(307), "TT852434", 2 },
                    { 5, new DateTime(2022, 11, 15, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(308), "TT852435", 2 },
                    { 6, new DateTime(2022, 9, 22, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(309), "TT852436", 3 },
                    { 7, new DateTime(2022, 11, 21, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(311), "TT852437", 4 },
                    { 8, new DateTime(2022, 11, 18, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(312), "TT852438", 4 },
                    { 9, new DateTime(2022, 11, 23, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(313), "TT852439", 4 },
                    { 10, new DateTime(2022, 10, 13, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(314), "TT853437", 5 },
                    { 11, new DateTime(2022, 9, 11, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(317), "TT854437", 5 },
                    { 12, new DateTime(2022, 11, 23, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(318), "TT855437", 5 },
                    { 13, new DateTime(2022, 10, 8, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(319), "TT856437", 5 },
                    { 14, new DateTime(2022, 9, 13, 12, 10, 29, 398, DateTimeKind.Local).AddTicks(320), "TT857437", 5 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "OrderId", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, "Бронза D20", 1, 200.55m, "мм" },
                    { 2, "Алюминий D500", 1, 0.350m, "м" },
                    { 3, "Медь D10 L1000", 1, 50.00m, "шт" },
                    { 4, "Бронза D45", 1, 450.80m, "мм" },
                    { 5, "Латунь D80", 1, 10.70m, "м" },
                    { 6, "Труба профильная 20х20х1,5", 4, 500.87m, "кг" },
                    { 7, "Труба профильная 25х25х1,5", 4, 250.00m, "кг" },
                    { 8, "Труба профильная 40х60х2", 4, 0.92m, "т" },
                    { 9, "Труба профильная 40х40х1,5", 4, 2.36m, "т" },
                    { 10, "Труба профильная 80х60х2,5", 4, 10.45m, "т" },
                    { 11, "Арматура D10", 4, 8.25m, "т" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProviderId",
                table: "Orders",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
