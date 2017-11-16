namespace GameraBazaar.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CamerasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camerasc_AspNetUsers_UserId",
                table: "Camerasc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Camerasc",
                table: "Camerasc");

            migrationBuilder.RenameTable(
                name: "Camerasc",
                newName: "Cameras");

            migrationBuilder.RenameIndex(
                name: "IX_Camerasc_UserId",
                table: "Cameras",
                newName: "IX_Cameras_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cameras",
                table: "Cameras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cameras_AspNetUsers_UserId",
                table: "Cameras",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cameras_AspNetUsers_UserId",
                table: "Cameras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cameras",
                table: "Cameras");

            migrationBuilder.RenameTable(
                name: "Cameras",
                newName: "Camerasc");

            migrationBuilder.RenameIndex(
                name: "IX_Cameras_UserId",
                table: "Camerasc",
                newName: "IX_Camerasc_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Camerasc",
                table: "Camerasc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Camerasc_AspNetUsers_UserId",
                table: "Camerasc",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
