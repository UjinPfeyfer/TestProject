using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class dimension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificates_ElementOfSections_ElementOfsectionId",
                table: "ElementOfSectionSignificates");

            migrationBuilder.RenameColumn(
                name: "ElementOfsectionId",
                table: "ElementOfSectionSignificates",
                newName: "ElementOfSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificates_ElementOfsectionId",
                table: "ElementOfSectionSignificates",
                newName: "IX_ElementOfSectionSignificates_ElementOfSectionId");

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    DimensionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DimensionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.DimensionId);
                });

            migrationBuilder.CreateTable(
                name: "DimentionTrees",
                columns: table => new
                {
                    DimensionTreeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DemensionId = table.Column<int>(nullable: false),
                    DescendantId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimentionTrees", x => x.DimensionTreeId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificates_ElementOfSections_ElementOfSectionId",
                table: "ElementOfSectionSignificates",
                column: "ElementOfSectionId",
                principalTable: "ElementOfSections",
                principalColumn: "ElementOfSectionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificates_ElementOfSections_ElementOfSectionId",
                table: "ElementOfSectionSignificates");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "DimentionTrees");

            migrationBuilder.RenameColumn(
                name: "ElementOfSectionId",
                table: "ElementOfSectionSignificates",
                newName: "ElementOfsectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificates_ElementOfSectionId",
                table: "ElementOfSectionSignificates",
                newName: "IX_ElementOfSectionSignificates_ElementOfsectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificates_ElementOfSections_ElementOfsectionId",
                table: "ElementOfSectionSignificates",
                column: "ElementOfsectionId",
                principalTable: "ElementOfSections",
                principalColumn: "ElementOfSectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
