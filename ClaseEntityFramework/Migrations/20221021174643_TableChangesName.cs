using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaseEntityFramework.Migrations
{
    public partial class TableChangesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "PRO_STOCK");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "PRO_PRICE");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "PRO_NAME");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Products",
                newName: "PRO_ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "PRO_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductCategories",
                newName: "PRO_NAME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductCategories",
                newName: "PRO_ID");

            migrationBuilder.RenameColumn(
                name: "Register",
                table: "Orders",
                newName: "ORD_REGISTER");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "ORD_ID");

            migrationBuilder.RenameColumn(
                name: "SubTotal",
                table: "OrderDetails",
                newName: "ORD_SUBTOTAL");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetails",
                newName: "ORD_PRICE");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "OrderDetails",
                newName: "ORD_COUNT");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetails",
                newName: "ORD_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "CLI_NAME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "CLI_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRO_STOCK",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "PRO_PRICE",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PRO_NAME",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PRO_ACTIVE",
                table: "Products",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "PRO_ID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PRO_NAME",
                table: "ProductCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PRO_ID",
                table: "ProductCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ORD_REGISTER",
                table: "Orders",
                newName: "Register");

            migrationBuilder.RenameColumn(
                name: "ORD_ID",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ORD_SUBTOTAL",
                table: "OrderDetails",
                newName: "SubTotal");

            migrationBuilder.RenameColumn(
                name: "ORD_PRICE",
                table: "OrderDetails",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ORD_COUNT",
                table: "OrderDetails",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "ORD_ID",
                table: "OrderDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CLI_NAME",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CLI_ID",
                table: "Clients",
                newName: "Id");
        }
    }
}
