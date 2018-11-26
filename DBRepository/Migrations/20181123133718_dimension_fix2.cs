using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class dimension_fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DimensionTableId",
                table: "Dimensions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DimentionTableId",
                table: "Dimensions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DimentionTable",
                columns: table => new
                {
                    DimentionTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DimentionTableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimentionTable", x => x.DimentionTableId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DimentionTrees_DimensionId",
                table: "DimentionTrees",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DimentionTableId",
                table: "Dimensions",
                column: "DimentionTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_DimentionTable_DimentionTableId",
                table: "Dimensions",
                column: "DimentionTableId",
                principalTable: "DimentionTable",
                principalColumn: "DimentionTableId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DimentionTrees_Dimensions_DimensionId",
                table: "DimentionTrees",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "DimensionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_DimentionTable_DimentionTableId",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_DimentionTrees_Dimensions_DimensionId",
                table: "DimentionTrees");

            migrationBuilder.DropTable(
                name: "DimentionTable");

            migrationBuilder.DropIndex(
                name: "IX_DimentionTrees_DimensionId",
                table: "DimentionTrees");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_DimentionTableId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "DimensionTableId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "DimentionTableId",
                table: "Dimensions");
        }
    }
}
