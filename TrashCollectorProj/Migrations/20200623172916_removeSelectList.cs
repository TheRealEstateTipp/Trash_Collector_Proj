using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class removeSelectList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abba627e-dd95-4749-b018-dcf4829c7c08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c860a2b1-0e0e-402c-8bbf-63e940d1c3ed");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserID",
                table: "Employees",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a8e690a-8e26-42f7-bf8b-e66edcb1544e", "a7369325-5b0b-4d98-bdfb-3e4b5a79ceca", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3182bd5-a0af-4966-80f5-72b8abc2dcce", "96860ec1-e67e-4795-8f4f-a0a2bfad8b36", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentityUserID",
                table: "Employees",
                column: "IdentityUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_IdentityUserID",
                table: "Employees",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_IdentityUserID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IdentityUserID",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a8e690a-8e26-42f7-bf8b-e66edcb1544e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3182bd5-a0af-4966-80f5-72b8abc2dcce");

            migrationBuilder.DropColumn(
                name: "IdentityUserID",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abba627e-dd95-4749-b018-dcf4829c7c08", "43f91b37-ad5e-44eb-932b-96671c08ef3e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c860a2b1-0e0e-402c-8bbf-63e940d1c3ed", "73c96071-4acf-4dc1-9954-d2c864375587", "Customer", "CUSTOMER" });
        }
    }
}
