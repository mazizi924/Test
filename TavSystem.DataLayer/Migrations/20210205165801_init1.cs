using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TavSystem.DataLayer.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    MinInventory = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invitems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvitemNo = table.Column<string>(nullable: true),
                    InvitemDate = table.Column<DateTimeOffset>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invitems_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryNo = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deliveries_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accountingDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNo = table.Column<string>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    InvitemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountingDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accountingDocuments_invitems_InvitemId",
                        column: x => x.InvitemId,
                        principalTable: "invitems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invitemDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    InvitemId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invitemDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invitemDetails_invitems_InvitemId",
                        column: x => x.InvitemId,
                        principalTable: "invitems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invitemDetails_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountingDocuments_InvitemId",
                table: "accountingDocuments",
                column: "InvitemId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_ParentId",
                table: "categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_deliveries_ProductId",
                table: "deliveries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_invitemDetails_InvitemId",
                table: "invitemDetails",
                column: "InvitemId");

            migrationBuilder.CreateIndex(
                name: "IX_invitemDetails_ProductId",
                table: "invitemDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_invitems_CustomerId",
                table: "invitems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountingDocuments");

            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropTable(
                name: "invitemDetails");

            migrationBuilder.DropTable(
                name: "invitems");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
