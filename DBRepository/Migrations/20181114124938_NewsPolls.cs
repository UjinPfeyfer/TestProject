using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class NewsPolls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSections_Sections_SectionId",
                table: "ElementOfSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Significatives_Subheadings_SubheadingId",
                table: "Significatives");

            migrationBuilder.DropForeignKey(
                name: "FK_Subheadings_Headings_HeadingId",
                table: "Subheadings");

            migrationBuilder.AlterColumn<int>(
                name: "HeadingId",
                table: "Subheadings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubheadingId",
                table: "Significatives",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "ElementOfSections",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(nullable: true),
                    CreatingTime = table.Column<DateTime>(nullable: false),
                    UpdatingTime = table.Column<DateTime>(nullable: false),
                    NewsText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    PollId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(nullable: true),
                    CreatingTime = table.Column<DateTime>(nullable: false),
                    UpdatingTime = table.Column<DateTime>(nullable: false),
                    IntervieweeCount = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.PollId);
                    table.ForeignKey(
                        name: "FK_Polls_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollAnswers",
                columns: table => new
                {
                    PollAnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PollAnswerText = table.Column<string>(nullable: true),
                    PollId = table.Column<int>(nullable: false),
                    IsAnswerRight = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollAnswers", x => x.PollAnswerId);
                    table.ForeignKey(
                        name: "FK_PollAnswers_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollAnswers_PollId",
                table: "PollAnswers",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_CreatorId",
                table: "Polls",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSections_Sections_SectionId",
                table: "ElementOfSections",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Significatives_Subheadings_SubheadingId",
                table: "Significatives",
                column: "SubheadingId",
                principalTable: "Subheadings",
                principalColumn: "SubheadingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subheadings_Headings_HeadingId",
                table: "Subheadings",
                column: "HeadingId",
                principalTable: "Headings",
                principalColumn: "HeadingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSections_Sections_SectionId",
                table: "ElementOfSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Significatives_Subheadings_SubheadingId",
                table: "Significatives");

            migrationBuilder.DropForeignKey(
                name: "FK_Subheadings_Headings_HeadingId",
                table: "Subheadings");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PollAnswers");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.AlterColumn<int>(
                name: "HeadingId",
                table: "Subheadings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SubheadingId",
                table: "Significatives",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "ElementOfSections",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSections_Sections_SectionId",
                table: "ElementOfSections",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Significatives_Subheadings_SubheadingId",
                table: "Significatives",
                column: "SubheadingId",
                principalTable: "Subheadings",
                principalColumn: "SubheadingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subheadings_Headings_HeadingId",
                table: "Subheadings",
                column: "HeadingId",
                principalTable: "Headings",
                principalColumn: "HeadingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
