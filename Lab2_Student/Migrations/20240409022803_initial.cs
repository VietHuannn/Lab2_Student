using System;
using Microsoft.EntityFrameworkCore.Migrations;


namespace Lab2_Student.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Description" },
                values: new object[,]
                {
                    { new Guid("88738493-3a85-4443-8f6a-313453432192"), "Phim", "Phim that chill" },
                    { new Guid("9250d994-2558-4573-8465-417248667051"), "CSDL", "So do ERD" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Name" },
                values: new object[,]
                {
                    { new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"), "Nguyen Thi Nhi" },
                    { new Guid("e2397972-8743-431a-9482-60292f08320e"), "Le Viet Huan" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CoursesId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("9250d994-2558-4573-8465-417248667051"), new Guid("4e79044a-988d-4488-97b7-3e474e4340d2") },
                    { new Guid("88738493-3a85-4443-8f6a-313453432192"), new Guid("e2397972-8743-431a-9482-60292f08320e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CoursesId",
                table: "StudentCourses",
                column: "CoursesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
