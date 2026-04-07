using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VgcCollege.Web.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixAllErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentResults_Students_StudentProfileId",
                table: "AssignmentResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseId1",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseId1",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_Students_StudentProfileId",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Branches_BranchId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Students_StudentProfileId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseId1",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserId1",
                table: "Students");

            migrationBuilder.DropTable(
                name: "FacultyProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CourseId1",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrollments_CourseId1",
                table: "CourseEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_CourseId1",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_IdentityUserId1",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "CourseEnrollments");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentProfiles");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameIndex(
                name: "IX_Students_IdentityUserId",
                table: "StudentProfiles",
                newName: "IX_StudentProfiles_IdentityUserId");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "StudentProfiles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentResults_StudentProfiles_StudentProfileId",
                table: "AssignmentResults",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_StudentProfiles_StudentProfileId",
                table: "CourseEnrollments",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Branch_BranchId",
                table: "Courses",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_StudentProfiles_StudentProfileId",
                table: "ExamResults",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_AspNetUsers_IdentityUserId",
                table: "StudentProfiles",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentResults_StudentProfiles_StudentProfileId",
                table: "AssignmentResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollments_StudentProfiles_StudentProfileId",
                table: "CourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Branch_BranchId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_StudentProfiles_StudentProfileId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_AspNetUsers_IdentityUserId",
                table: "StudentProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.RenameTable(
                name: "StudentProfiles",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProfiles_IdentityUserId",
                table: "Students",
                newName: "IX_Students_IdentityUserId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Exams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "CourseEnrollments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Assignments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FacultyProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdentityUserId = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseId1",
                table: "Exams",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_CourseId1",
                table: "CourseEnrollments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId1",
                table: "Assignments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdentityUserId1",
                table: "Students",
                column: "IdentityUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyProfiles_IdentityUserId",
                table: "FacultyProfiles",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentResults_Students_StudentProfileId",
                table: "AssignmentResults",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseId1",
                table: "Assignments",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Courses_CourseId1",
                table: "CourseEnrollments",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollments_Students_StudentProfileId",
                table: "CourseEnrollments",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Branches_BranchId",
                table: "Courses",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Students_StudentProfileId",
                table: "ExamResults",
                column: "StudentProfileId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId1",
                table: "Exams",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserId",
                table: "Students",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserId1",
                table: "Students",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
