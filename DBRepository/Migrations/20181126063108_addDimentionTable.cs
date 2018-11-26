using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class addDimentionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_DimensionTable_DimensionTableId",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_DimentionTrees_Dimensions_DimensionId",
                table: "DimentionTrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DimentionTrees",
                table: "DimentionTrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DimensionTable",
                table: "DimensionTable");

            migrationBuilder.RenameTable(
                name: "DimentionTrees",
                newName: "DimensionTrees");

            migrationBuilder.RenameTable(
                name: "DimensionTable",
                newName: "DimensionTables");

            migrationBuilder.RenameIndex(
                name: "IX_DimentionTrees_DimensionId",
                table: "DimensionTrees",
                newName: "IX_DimensionTrees_DimensionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DimensionTrees",
                table: "DimensionTrees",
                column: "DimensionTreeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DimensionTables",
                table: "DimensionTables",
                column: "DimensionTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_DimensionTables_DimensionTableId",
                table: "Dimensions",
                column: "DimensionTableId",
                principalTable: "DimensionTables",
                principalColumn: "DimensionTableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DimensionTrees_Dimensions_DimensionId",
                table: "DimensionTrees",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "DimensionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_DimensionTables_DimensionTableId",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_DimensionTrees_Dimensions_DimensionId",
                table: "DimensionTrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DimensionTrees",
                table: "DimensionTrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DimensionTables",
                table: "DimensionTables");

            migrationBuilder.RenameTable(
                name: "DimensionTrees",
                newName: "DimentionTrees");

            migrationBuilder.RenameTable(
                name: "DimensionTables",
                newName: "DimensionTable");

            migrationBuilder.RenameIndex(
                name: "IX_DimensionTrees_DimensionId",
                table: "DimentionTrees",
                newName: "IX_DimentionTrees_DimensionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DimentionTrees",
                table: "DimentionTrees",
                column: "DimensionTreeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DimensionTable",
                table: "DimensionTable",
                column: "DimensionTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_DimensionTable_DimensionTableId",
                table: "Dimensions",
                column: "DimensionTableId",
                principalTable: "DimensionTable",
                principalColumn: "DimensionTableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DimentionTrees_Dimensions_DimensionId",
                table: "DimentionTrees",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "DimensionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
