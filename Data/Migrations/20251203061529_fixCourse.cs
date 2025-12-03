using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMS.Migrations
{
    /// <inheritdoc />
    public partial class fixCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_LectureId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LectureId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LectureId1",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "LectureId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LectureId",
                table: "Courses",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_LectureId",
                table: "Courses",
                column: "LectureId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_LectureId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LectureId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "LectureId",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "LectureId1",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LectureId1",
                table: "Courses",
                column: "LectureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_LectureId1",
                table: "Courses",
                column: "LectureId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
