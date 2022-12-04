using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SambaBurguer.Migrations
{
    /// <inheritdoc />
    public partial class employerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Shops_ShopId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Sales",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_ShopId",
                table: "Sales",
                newName: "IX_Sales_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Employees_EmployeeId",
                table: "Sales",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Employees_EmployeeId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Sales",
                newName: "ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                newName: "IX_Sales_ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Shops_ShopId",
                table: "Sales",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
