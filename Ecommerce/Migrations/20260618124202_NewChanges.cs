using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleDetails_UserDetails_UserId",
                table: "RoleDetails");

            migrationBuilder.DropIndex(
                name: "IX_RoleDetails_UserId",
                table: "RoleDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoleDetails");

            migrationBuilder.CreateTable(
                name: "UserRoleDetails",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleDetails", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoleDetails_RoleDetails_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleDetails",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleDetails_UserDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleDetails_UserId",
                table: "UserRoleDetails",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleDetails");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RoleDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleDetails_UserId",
                table: "RoleDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleDetails_UserDetails_UserId",
                table: "RoleDetails",
                column: "UserId",
                principalTable: "UserDetails",
                principalColumn: "UserId");
        }
    }
}
