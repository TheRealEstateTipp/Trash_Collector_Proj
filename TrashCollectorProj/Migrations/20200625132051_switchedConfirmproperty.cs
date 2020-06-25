using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProj.Migrations
{
    public partial class switchedConfirmproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a8e690a-8e26-42f7-bf8b-e66edcb1544e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3182bd5-a0af-4966-80f5-72b8abc2dcce");

            migrationBuilder.DropColumn(
                name: "PickUpConfirmation",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "PickUpConfirmed",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb5456f0-5262-453b-9307-db8c68ac9556", "0748a137-c7d3-447c-97fa-cb929689269a", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f736a762-02d7-4e9d-b8a2-ca7b91a129b3", "2798f55b-0b62-46f5-8b04-a1f34e15c708", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f736a762-02d7-4e9d-b8a2-ca7b91a129b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb5456f0-5262-453b-9307-db8c68ac9556");

            migrationBuilder.DropColumn(
                name: "PickUpConfirmed",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "PickUpConfirmation",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a8e690a-8e26-42f7-bf8b-e66edcb1544e", "a7369325-5b0b-4d98-bdfb-3e4b5a79ceca", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3182bd5-a0af-4966-80f5-72b8abc2dcce", "96860ec1-e67e-4795-8f4f-a0a2bfad8b36", "Customer", "CUSTOMER" });
        }
    }
}
