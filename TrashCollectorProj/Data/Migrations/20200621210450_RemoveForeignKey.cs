using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Data.Migrations
{
    public partial class RemoveForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Customer_CustomerID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CustomerID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CustomerID",
                table: "Employee",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Customer_CustomerID",
                table: "Employee",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
