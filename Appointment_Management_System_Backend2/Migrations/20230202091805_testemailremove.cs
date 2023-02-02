using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointment_Management_System_Backend2.Migrations
{
    public partial class testemailremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

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
    }
}
