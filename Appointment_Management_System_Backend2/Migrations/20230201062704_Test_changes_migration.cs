using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointment_Management_System_Backend2.Migrations
{
    public partial class Test_changes_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientUserId",
                table: "PatientDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorAssignedId",
                table: "PatientDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorDetailsId",
                table: "PatientDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetails_DoctorDetailsId",
                table: "PatientDetails",
                column: "DoctorDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDetails_DoctorDetails_DoctorDetailsId",
                table: "PatientDetails",
                column: "DoctorDetailsId",
                principalTable: "DoctorDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDetails_DoctorDetails_DoctorDetailsId",
                table: "PatientDetails");

            migrationBuilder.DropIndex(
                name: "IX_PatientDetails_DoctorDetailsId",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "DoctorAssignedId",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "DoctorDetailsId",
                table: "PatientDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PatientUserId",
                table: "PatientDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
