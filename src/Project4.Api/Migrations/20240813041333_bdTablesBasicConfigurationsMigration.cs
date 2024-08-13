using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project4.Api.Migrations
{
    /// <inheritdoc />
    public partial class bdTablesBasicConfigurationsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Origin = table.Column<string>(type: "text", nullable: true),
                    ImportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GrossPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ProfitMargin = table.Column<decimal>(type: "numeric", nullable: true),
                    ImportCost = table.Column<decimal>(type: "numeric", nullable: true),
                    TransportCost = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    CatalogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CatalogDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.CatalogId);
                    table.UniqueConstraint("AK_Catalogs_ProductCode", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "marcas_autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", maxLength: 100, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas_autos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductCodeId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ImportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BatchId = table.Column<int>(type: "integer", nullable: true),
                    Available = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batch",
                        principalColumn: "BatchId");
                    table.ForeignKey(
                        name: "FK_Products_Catalogs_ProductCodeId",
                        column: x => x.ProductCodeId,
                        principalTable: "Catalogs",
                        principalColumn: "ProductCode");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalDue = table.Column<decimal>(type: "numeric", nullable: true),
                    BillTo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Product_detail",
                columns: table => new
                {
                    ProductDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: true),
                    UnitaryPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ProductImage = table.Column<string>(type: "text", nullable: true),
                    ProductModel = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_detail", x => x.ProductDetailId);
                    table.ForeignKey(
                        name: "FK_Product_detail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "marcas_autos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yaris" },
                    { 2, "Celica" },
                    { 3, "Supra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_ProductCode",
                table: "Catalogs",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ProductId",
                table: "Invoice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_detail_ProductId",
                table: "Product_detail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BatchId",
                table: "Products",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCodeId",
                table: "Products",
                column: "ProductCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "marcas_autos");

            migrationBuilder.DropTable(
                name: "Product_detail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
