using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class dimcheck2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_DimentionTable_DimentionTableId",
                table: "Dimensions");

            migrationBuilder.DropTable(
                name: "DimentionTable");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_DimentionTableId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "DimentionTableId",
                table: "Dimensions");

            migrationBuilder.CreateTable(
                name: "DimensionTable",
                columns: table => new
                {
                    DimensionTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DimensionTableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionTable", x => x.DimensionTableId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DimensionTableId",
                table: "Dimensions",
                column: "DimensionTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_DimensionTable_DimensionTableId",
                table: "Dimensions",
                column: "DimensionTableId",
                principalTable: "DimensionTable",
                principalColumn: "DimensionTableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_DimensionTable_DimensionTableId",
                table: "Dimensions");

            migrationBuilder.DropTable(
                name: "DimensionTable");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_DimensionTableId",
                table: "Dimensions");

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
        }
    }
}
