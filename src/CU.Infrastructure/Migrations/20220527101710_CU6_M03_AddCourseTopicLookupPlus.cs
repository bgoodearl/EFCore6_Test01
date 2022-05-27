using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CU.Infrastructure.Migrations
{
    public partial class CU6_M03_AddCourseTopicLookupPlus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "xLookups10cKey",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LookupTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    _SubType = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xLookups10cKey", x => new { x.LookupTypeId, x.Code });
                    table.ForeignKey(
                        name: "FK_xLookups10cKey_xLookupTypes_LookupTypeId",
                        column: x => x.LookupTypeId,
                        principalTable: "xLookupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_coursesTopics",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    CourseTopicsLookupTypeId = table.Column<short>(type: "smallint", nullable: false),
                    CourseTopicsCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coursesTopics", x => new { x.CourseID, x.CourseTopicsLookupTypeId, x.CourseTopicsCode });
                    table.ForeignKey(
                        name: "FK__coursesTopics_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__coursesTopics_xLookups10cKey_CourseTopicsLookupTypeId_CourseTopicsCode",
                        columns: x => new { x.CourseTopicsLookupTypeId, x.CourseTopicsCode },
                        principalTable: "xLookups10cKey",
                        principalColumns: new[] { "LookupTypeId", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__coursesTopics_CourseTopicsLookupTypeId_CourseTopicsCode",
                table: "_coursesTopics",
                columns: new[] { "CourseTopicsLookupTypeId", "CourseTopicsCode" });

            migrationBuilder.CreateIndex(
                name: "LookupTypeAndName",
                table: "xLookups10cKey",
                columns: new[] { "LookupTypeId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_coursesTopics");

            migrationBuilder.DropTable(
                name: "xLookups10cKey");
        }
    }
}
