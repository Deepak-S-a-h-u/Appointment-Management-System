using Microsoft.EntityFrameworkCore.Migrations;

namespace Appointment_Management_System_Backend.Migrations
{
    public partial class Reception_edited_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDetails_AspNetUsers_ApplicationUserId1",
                table: "DoctorDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDetails_Genders_GenderId",
                table: "DoctorDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDetails_AspNetUsers_ApplicationUserId1",
                table: "PatientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDetails_Departments_DepartmentId",
                table: "PatientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDetails_Genders_GenderId",
                table: "PatientDetails");

            migrationBuilder.DropIndex(
                name: "IX_PatientDetails_ApplicationUserId1",
                table: "PatientDetails");

            migrationBuilder.DropIndex(
                name: "IX_PatientDetails_DepartmentId",
                table: "PatientDetails");

            migrationBuilder.DropIndex(
                name: "IX_PatientDetails_GenderId",
                table: "PatientDetails");

            migrationBuilder.DropIndex(
                name: "IX_DoctorDetails_ApplicationUserId1",
                table: "DoctorDetails");

            migrationBuilder.DropIndex(
                name: "IX_DoctorDetails_GenderId",
                table: "DoctorDetails");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DoctorDetails");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "DoctorDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DoctorDetails");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "PatientDetails",
                newName: "PatientUserId");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "DoctorDetails",
                newName: "DoctorUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppointmentDetails",
                newName: "PatientId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PatientDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "DoctorDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetails_ApplicationUserId",
                table: "PatientDetails",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetails_ApplicationUserId",
                table: "DoctorDetails",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDetails_AspNetUsers_ApplicationUserId",
                table: "DoctorDetails",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDetails_AspNetUsers_ApplicationUserId",
                table: "PatientDetails",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDetails_AspNetUsers_ApplicationUserId",
                table: "DoctorDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDetails_AspNetUsers_ApplicationUserId",
                table: "PatientDetails");

            migrationBuilder.DropIndex(
                name: "IX_PatientDetails_ApplicationUserId",
                table: "PatientDetails");

            migrationBuilder.DropIndex(
                name: "IX_DoctorDetails_ApplicationUserId",
                table: "DoctorDetails");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PatientUserId",
                table: "PatientDetails",
                newName: "GenderId");

            migrationBuilder.RenameColumn(
                name: "DoctorUserId",
                table: "DoctorDetails",
                newName: "GenderId");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "AppointmentDetails",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "PatientDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PatientDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "PatientDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PatientDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "PatientDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PatientDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "DoctorDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DoctorDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "DoctorDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DoctorDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetails_ApplicationUserId1",
                table: "PatientDetails",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetails_DepartmentId",
                table: "PatientDetails",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDetails_GenderId",
                table: "PatientDetails",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetails_ApplicationUserId1",
                table: "DoctorDetails",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDetails_GenderId",
                table: "DoctorDetails",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDetails_AspNetUsers_ApplicationUserId1",
                table: "DoctorDetails",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDetails_Genders_GenderId",
                table: "DoctorDetails",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDetails_AspNetUsers_ApplicationUserId1",
                table: "PatientDetails",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDetails_Departments_DepartmentId",
                table: "PatientDetails",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDetails_Genders_GenderId",
                table: "PatientDetails",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
