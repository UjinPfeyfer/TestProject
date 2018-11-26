using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class changeCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Significatives_Countries_CountryId",
                table: "Significatives");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Significatives",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "ElementOfSectionSignificate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ElementOfSectionSignificate_CountryId",
                table: "ElementOfSectionSignificate",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementOfSectionSignificate_Countries_CountryId",
                table: "ElementOfSectionSignificate",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Significatives_Countries_CountryId",
                table: "Significatives",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementOfSectionSignificate_Countries_CountryId",
                table: "ElementOfSectionSignificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Significatives_Countries_CountryId",
                table: "Significatives");

            migrationBuilder.DropIndex(
                name: "IX_ElementOfSectionSignificate_CountryId",
                table: "ElementOfSectionSignificate");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ElementOfSectionSignificate");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Significatives",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Significatives_Countries_CountryId",
                table: "Significatives",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
