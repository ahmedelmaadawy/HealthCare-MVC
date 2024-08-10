using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class intialdoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ContactNumber", "FirstName", "LastName", "OfficeAddress", "Specialization" },
                values: new object[] { 3, "123-456-7890", "John", "Doe", "123 Heart Lane", "Cardiology" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ContactNumber", "FirstName", "LastName", "OfficeAddress", "Specialization" },
                values: new object[] { 1, "123-456-7890", "John", "Doe", "123 Heart Lane", "Cardiology" });
        }
    }
}
