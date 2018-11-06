using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Data1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_AspNetUsers_OwnerId1",
                table: "Datas");

            migrationBuilder.DropIndex(
                name: "IX_Datas_OwnerId1",
                table: "Datas");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Datas");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Datas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Datas_OwnerId",
                table: "Datas",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_AspNetUsers_OwnerId",
                table: "Datas",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_AspNetUsers_OwnerId",
                table: "Datas");

            migrationBuilder.DropIndex(
                name: "IX_Datas_OwnerId",
                table: "Datas");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Datas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Datas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Datas_OwnerId1",
                table: "Datas",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_AspNetUsers_OwnerId1",
                table: "Datas",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
