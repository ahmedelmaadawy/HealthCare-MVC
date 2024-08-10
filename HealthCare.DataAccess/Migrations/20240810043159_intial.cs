using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthCare.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ContactNumber", "FirstName", "LastName", "OfficeAddress", "Specialization" },
                values: new object[,]
                {
                    { 3, "123-456-7890", "John", "Doe", "123 Heart Lane", "Cardiology" },
                    { 2, "987-654-3210", "Jane", "Smith", "456 Brain Blvd", "Neurology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Adderss", "ContactNumber", "DateOfBirth", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, "789 Elm Street", "111-222-3333", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "Female", "Johnson" },
                    { 2, "321 Oak Avenue", "444-555-6666", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "Male", "Williams" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DateTime", "DoctorId", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0 },
                    { 2, new DateTime(2024, 8, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "Date", "Description", "DoctorID", "PatientID", "Prescription" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine Checkup", 1, 1, "Take 1 tablet of aspirin daily" },
                    { 2, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Migraine Treatment", 2, 2, "Rest and Hydrate" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "DoctorID", "IsAvailable", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2024, 8, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, true, new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, true, new DateTime(2024, 8, 10, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
