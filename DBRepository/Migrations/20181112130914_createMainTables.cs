using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class createMainTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.CreateTable(
                name: "Headings",
                columns: table => new
                {
                    HeadingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeadingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headings", x => x.HeadingId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Subheadings",
                columns: table => new
                {
                    SubheadingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubheadingName = table.Column<string>(nullable: true),
                    HeadingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subheadings", x => x.SubheadingId);
                    table.ForeignKey(
                        name: "FK_Subheadings_Headings_HeadingId",
                        column: x => x.HeadingId,
                        principalTable: "Headings",
                        principalColumn: "HeadingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementOfSections",
                columns: table => new
                {
                    ElementOfSectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElementOfSectionName = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementOfSections", x => x.ElementOfSectionId);
                    table.ForeignKey(
                        name: "FK_ElementOfSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Significatives",
                columns: table => new
                {
                    SignificativeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SignificativeName = table.Column<string>(nullable: true),
                    SubheadingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Significatives", x => x.SignificativeId);
                    table.ForeignKey(
                        name: "FK_Significatives_Subheadings_SubheadingId",
                        column: x => x.SubheadingId,
                        principalTable: "Subheadings",
                        principalColumn: "SubheadingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementOfSectionSignificate",
                columns: table => new
                {
                    ElementOfSectionSignificateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElementOfsectionId = table.Column<int>(nullable: false),
                    SignificativeId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Count = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementOfSectionSignificate", x => x.ElementOfSectionSignificateId);
                    table.ForeignKey(
                        name: "FK_ElementOfSectionSignificate_ElementOfSections_ElementOfsectionId",
                        column: x => x.ElementOfsectionId,
                        principalTable: "ElementOfSections",
                        principalColumn: "ElementOfSectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementOfSectionSignificate_Significatives_SignificativeId",
                        column: x => x.SignificativeId,
                        principalTable: "Significatives",
                        principalColumn: "SignificativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementOfSections_SectionId",
                table: "ElementOfSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementOfSectionSignificate_ElementOfsectionId",
                table: "ElementOfSectionSignificate",
                column: "ElementOfsectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementOfSectionSignificate_SignificativeId",
                table: "ElementOfSectionSignificate",
                column: "SignificativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Significatives_SubheadingId",
                table: "Significatives",
                column: "SubheadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Subheadings_HeadingId",
                table: "Subheadings",
                column: "HeadingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementOfSectionSignificate");

            migrationBuilder.DropTable(
                name: "ElementOfSections");

            migrationBuilder.DropTable(
                name: "Significatives");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Subheadings");

            migrationBuilder.DropTable(
                name: "Headings");

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataForm = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datas_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datas_OwnerId",
                table: "Datas",
                column: "OwnerId");
        }
    }
}
