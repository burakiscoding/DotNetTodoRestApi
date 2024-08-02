using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTodoRestApi.Migrations
{
    /// <inheritdoc />
    public partial class LikedTodos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58459fbc-5be7-427b-bb48-ab710382b381");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aedc9690-318f-4ad6-bb7a-1bc859d8a455");

            migrationBuilder.CreateTable(
                name: "LikedTodos",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TodoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedTodos", x => new { x.AppUserId, x.TodoId });
                    table.ForeignKey(
                        name: "FK_LikedTodos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedTodos_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "794b8c89-565b-447e-ba56-e2369dcd0416", null, "Admin", "ADMIN" },
                    { "c8e5cc0c-2f6b-47b0-9c48-4ec7b2ec396f", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedTodos_TodoId",
                table: "LikedTodos",
                column: "TodoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedTodos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "794b8c89-565b-447e-ba56-e2369dcd0416");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8e5cc0c-2f6b-47b0-9c48-4ec7b2ec396f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58459fbc-5be7-427b-bb48-ab710382b381", null, "Admin", "ADMIN" },
                    { "aedc9690-318f-4ad6-bb7a-1bc859d8a455", null, "User", "USER" }
                });
        }
    }
}
