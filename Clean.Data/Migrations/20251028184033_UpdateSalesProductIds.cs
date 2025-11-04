using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesProductIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_sales_SalesId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_SalesId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "ProductIds",
                table: "sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "sales");

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_SalesId",
                table: "products",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_sales_SalesId",
                table: "products",
                column: "SalesId",
                principalTable: "sales",
                principalColumn: "Id");
        }
    }
}
