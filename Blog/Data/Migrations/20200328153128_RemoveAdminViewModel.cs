using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class RemoveAdminViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AdminViewModel_AdminViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AdminViewModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdminViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdminViewModelId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminViewModelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminViewModelId",
                table: "AspNetUsers",
                column: "AdminViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AdminViewModel_AdminViewModelId",
                table: "AspNetUsers",
                column: "AdminViewModelId",
                principalTable: "AdminViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
