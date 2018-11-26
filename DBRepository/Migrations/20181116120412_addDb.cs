using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class addDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificate_Countries_CountryId",
                table: "ElementOfSectionSignificate");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificate_ElementOfSections_ElementOfsectionId",
                table: "ElementOfSectionSignificate");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificate_Significatives_SignificativeId",
                table: "ElementOfSectionSignificate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElementOfSectionSignificate",
                table: "ElementOfSectionSignificate");

            migrationBuilder.RenameTable(
                name: "ElementOfSectionSignificate",
                newName: "ElementOfSectionSignificates");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificate_SignificativeId",
                table: "ElementOfSectionSignificates",
                newName: "IX_ElementOfSectionSignificates_SignificativeId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificate_ElementOfsectionId",
                table: "ElementOfSectionSignificates",
                newName: "IX_ElementOfSectionSignificates_ElementOfsectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificate_CountryId",
                table: "ElementOfSectionSignificates",
                newName: "IX_ElementOfSectionSignificates_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElementOfSectionSignificates",
                table: "ElementOfSectionSignificates",
                column: "ElementOfSectionSignificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificates_Countries_CountryId",
                table: "ElementOfSectionSignificates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificates_ElementOfSections_ElementOfsectionId",
                table: "ElementOfSectionSignificates",
                column: "ElementOfsectionId",
                principalTable: "ElementOfSections",
                principalColumn: "ElementOfSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificates_Significatives_SignificativeId",
                table: "ElementOfSectionSignificates",
                column: "SignificativeId",
                principalTable: "Significatives",
                principalColumn: "SignificativeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificates_Countries_CountryId",
                table: "ElementOfSectionSignificates");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificates_ElementOfSections_ElementOfsectionId",
                table: "ElementOfSectionSignificates");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificates_Significatives_SignificativeId",
                table: "ElementOfSectionSignificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElementOfSectionSignificates",
                table: "ElementOfSectionSignificates");

            migrationBuilder.RenameTable(
                name: "ElementOfSectionSignificates",
                newName: "ElementOfSectionSignificate");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificates_SignificativeId",
                table: "ElementOfSectionSignificate",
                newName: "IX_ElementOfSectionSignificate_SignificativeId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificates_ElementOfsectionId",
                table: "ElementOfSectionSignificate",
                newName: "IX_ElementOfSectionSignificate_ElementOfsectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementOfSectionSignificates_CountryId",
                table: "ElementOfSectionSignificate",
                newName: "IX_ElementOfSectionSignificate_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElementOfSectionSignificate",
                table: "ElementOfSectionSignificate",
                column: "ElementOfSectionSignificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificate_Countries_CountryId",
                table: "ElementOfSectionSignificate",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificate_ElementOfSections_ElementOfsectionId",
                table: "ElementOfSectionSignificate",
                column: "ElementOfsectionId",
                principalTable: "ElementOfSections",
                principalColumn: "ElementOfSectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificate_Significatives_SignificativeId",
                table: "ElementOfSectionSignificate",
                column: "SignificativeId",
                principalTable: "Significatives",
                principalColumn: "SignificativeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
