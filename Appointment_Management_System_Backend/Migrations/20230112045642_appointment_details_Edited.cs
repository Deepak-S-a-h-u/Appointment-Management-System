using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointment_Management_System_Backend.Migrations
{
    public partial class appointment_details_Edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_DoctorDetails_DoctorDetailsId",
                table: "AppointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_PatientDetails_PatientDetailsId",
                table: "AppointmentDetails");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AppointmentDetails");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "AppointmentDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PatientDetailsId",
                table: "AppointmentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorDetailsId",
                table: "AppointmentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_DoctorDetails_DoctorDetailsId",
                table: "AppointmentDetails",
                column: "DoctorDetailsId",
                principalTable: "DoctorDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_PatientDetails_PatientDetailsId",
                table: "AppointmentDetails",
                column: "PatientDetailsId",
                principalTable: "PatientDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_DoctorDetails_DoctorDetailsId",
                table: "AppointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_PatientDetails_PatientDetailsId",
                table: "AppointmentDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PatientDetailsId",
                table: "AppointmentDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorDetailsId",
                table: "AppointmentDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "AppointmentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "AppointmentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_DoctorDetails_DoctorDetailsId",
                table: "AppointmentDetails",
                column: "DoctorDetailsId",
                principalTable: "DoctorDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_PatientDetails_PatientDetailsId",
                table: "AppointmentDetails",
                column: "PatientDetailsId",
                principalTable: "PatientDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
