using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAllPendingMigrations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRecords_Patients_PatientId",
                table: "PatientRecords");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PatientRecords",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.RenameColumn(
                name: "Speciality",
                table: "AspNetUsers",
                newName: "State");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientRecords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinPhone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRecords_AspNetUsers_PatientId",
                table: "PatientRecords",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRecords_AspNetUsers_PatientId",
                table: "PatientRecords");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NextOfKinName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NextOfKinPhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatientNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "AspNetUsers",
                newName: "Speciality");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "PatientRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKinPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "Age", "City", "Country", "DateOfBirth", "FirstName", "LastName", "NextOfKinName", "NextOfKinPhone", "PatientNumber", "Phone", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 1, "Wits, Braam, Campus", 45, "Polokwane", "South Africa", "1990-12-13", "Lawrence", "Mugwena", "Percy", "0791069624", "LAWRE123", "0722247453", "1441", "Thohoyandou" },
                    { 2, "Wits, Braam, Campus", 45, "Polokwane", "South Africa", "1990-12-13", "John", "Thendo", "Percy", "0791069624", "JON123", "0722247453", "1441", "Thohoyandou" },
                    { 3, "Wits, Braam, Campus", 45, "Polokwane", "South Africa", "1990-12-13", "John", "Smith", "Percy", "0791069624", "LAWRE123", "0722247453", "1441", "Thohoyandou" }
                });

            migrationBuilder.InsertData(
                table: "PatientRecords",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "DoctorName", "PatientId", "RecordContext" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Smith", 1, "Initial consultation. Patient reports headaches and dizziness." },
                    { 2, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Johnson", 2, "Follow-up for respiratory symptoms. Prescribed cough syrup." },
                    { 3, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Lee", 3, "Routine check-up. Blood pressure slightly elevated." },
                    { 4, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Brown", 1, "Patient presents with abdominal pain. Recommended ultrasound." },
                    { 5, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Green", 2, "Routine diabetes check. A1C levels are stable." },
                    { 6, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Adams", 3, "Emergency visit for a sprained ankle. Applied a brace." },
                    { 7, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Davis", 1, "Consultation for back pain. Suggested physical therapy." },
                    { 8, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Wilson", 2, "Annual physical exam. Cholesterol levels high." },
                    { 9, new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Moore", 2, "Routine follow-up for high blood pressure. Medication adjusted." },
                    { 10, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Taylor", 1, "Patient experiencing insomnia. Prescribed sleep aids." },
                    { 11, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Martinez", 3, "Routine immunization. Administered flu vaccine." },
                    { 12, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Clark", 1, "Consultation for skin rash. Prescribed topical ointment." },
                    { 13, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Lewis", 2, "Follow-up for asthma. Adjusted inhaler dosage." },
                    { 14, new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Walker", 3, "Patient with persistent cough. Recommended chest X-ray." },
                    { 15, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Harris", 1, "Routine eye exam. No significant changes detected." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRecords_Patients_PatientId",
                table: "PatientRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
