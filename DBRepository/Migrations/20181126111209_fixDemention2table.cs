using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class fixDemention2table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_DimensionTables_DimensionTableId",
                table: "Dimensions");

            migrationBuilder.DropTable(
                name: "DimensionTables");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_DimensionTableId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "DimensionTableId",
                table: "Dimensions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DimensionTableId",
                table: "Dimensions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DimensionTables",
                columns: table => new
                {
                    DimensionTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DimensionTableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionTables", x => x.DimensionTableId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DimensionTableId",
                table: "Dimensions",
                column: "DimensionTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_DimensionTables_DimensionTableId",
                table: "Dimensions",
                column: "DimensionTableId",
                principalTable: "DimensionTables",
                principalColumn: "DimensionTableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
