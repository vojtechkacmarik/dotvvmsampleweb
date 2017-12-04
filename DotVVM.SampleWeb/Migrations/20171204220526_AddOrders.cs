using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotVVM.SampleWeb.Migrations
{
    public partial class AddOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactEmail = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Chai', 18.00)");
            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Chang', 19.00)");
            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Aniseed Syrup', 10.00)");
            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Chef Anton''s Cajun Seasoning', 22.00)");
            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Chef Anton''s Gumbo Mix', 21.35)");
            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Grandma''s Boysenberry Spread', 25.00)");
            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Uncle Bob''s Organic Dried Pears', 30.00)");
            migrationBuilder.Sql(@"INSERT INTO Products VALUES ('Northwoods Cranberry Sauce', 40.00)");

            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('argus@test-mail.com', '2015-04-17 12:04:07', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('betty@test-mail.com', '2017-02-09 20:08:52', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('carmen@test-mail.com', '2016-01-05 11:09:59', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('dominick@test-mail.com', '2016-06-01 22:10:03', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('ethan@test-mail.com', '2016-03-16 07:19:50', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('fiona@test-mail.com', '2017-10-15 06:04:59', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('greg@test-mail.com', '2015-12-24 15:13:35', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('harry@test-mail.com', '2015-10-27 06:24:34', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('ian@test-mail.com', '2017-09-19 19:40:29', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('jonathan@test-mail.com', '2016-10-07 23:46:01', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('katty@test-mail.com', '2017-12-04 05:51:09', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('linda@test-mail.com', '2016-01-18 16:48:53', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('miranda@test-mail.com', '2016-03-10 05:02:35', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('norma@test-mail.com', '2014-05-20 15:19:45', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('oprah@test-mail.com', '2015-11-30 23:54:22', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('penny@test-mail.com', '2015-09-28 02:18:38', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('quinn@test-mail.com', '2017-11-27 21:37:24', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('roy@test-mail.com', '2015-03-29 01:22:07', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('stan@test-mail.com', '2016-07-14 06:14:05', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('tommy@test-mail.com', '2016-08-16 13:19:29', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('ursula@test-mail.com', '2016-07-08 06:32:11', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('vendy@test-mail.com', '2017-09-04 15:00:04', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('wyatt@test-mail.com', '2015-12-01 23:15:17', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('yesman@test-mail.com', '2017-05-09 20:51:37', 0.00)");
            migrationBuilder.Sql(@"INSERT INTO Orders VALUES ('zelda@test-mail.com', '2016-05-22 12:16:53', 0.00)");

            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (1, 1, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (2, 1, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (2, 2, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (2, 3, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (2, 4, 7)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (2, 5, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (3, 1, 4)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (4, 1, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (4, 2, 7)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (4, 3, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (4, 4, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (5, 1, 2)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (5, 2, 2)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (5, 3, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (6, 1, 7)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (6, 2, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (6, 3, 4)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (6, 4, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (7, 1, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (8, 1, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (8, 2, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (8, 3, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (8, 4, 2)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (8, 5, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (9, 1, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (9, 2, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (9, 3, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (9, 4, 10)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (10, 1, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (10, 2, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (10, 3, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (10, 4, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (11, 1, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (11, 2, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (12, 1, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (12, 2, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (13, 1, 10)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (13, 2, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (13, 3, 7)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (13, 4, 2)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (13, 5, 4)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (14, 1, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (15, 1, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (15, 2, 2)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (15, 3, 7)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (15, 4, 2)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (16, 1, 4)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (16, 2, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (16, 3, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (16, 4, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (16, 5, 6)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (17, 1, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (17, 2, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (17, 3, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (17, 4, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (17, 5, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (18, 1, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (18, 2, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (18, 3, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (18, 4, 7)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (18, 5, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (19, 1, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (19, 2, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (19, 3, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (19, 4, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (19, 5, 6)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (20, 1, 3)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (20, 2, 4)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (20, 3, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (21, 1, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (22, 1, 6)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (22, 2, 6)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (22, 3, 7)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (22, 4, 2)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (22, 5, 1)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (23, 1, 5)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (24, 1, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (24, 2, 4)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (24, 3, 10)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (24, 4, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (25, 1, 9)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (25, 2, 8)");
            migrationBuilder.Sql(@"INSERT INTO OrderItems VALUES (25, 3, 3)");

            migrationBuilder.Sql(@"UPDATE Orders SET TotalPrice = (SELECT SUM(oi.Quantity * p.UnitPrice) FROM OrderItems oi JOIN Products p ON p.Id = oi.ProductId WHERE oi.OrderId = Orders.Id)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}