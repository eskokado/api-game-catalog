using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infra.Data.Migrations
{
    public partial class Player_Game_Star : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GameId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_Stars_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stars_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreateAt", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2021, 6, 10, 9, 5, 16, 975, DateTimeKind.Utc).AddTicks(9122), "Dra Pirilau", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2021, 6, 10, 9, 5, 16, 975, DateTimeKind.Utc).AddTicks(9175), "XanaCarnivora", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2021, 6, 10, 9, 5, 16, 975, DateTimeKind.Utc).AddTicks(9184), "Dapra20comer", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2021, 6, 10, 9, 5, 16, 975, DateTimeKind.Utc).AddTicks(9193), "Tatycomendo", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2021, 6, 10, 9, 5, 16, 975, DateTimeKind.Utc).AddTicks(9200), "Uhpapaichegou", null }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("bda5af3e-0856-41d6-acec-c32660988865"), new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(4808), "user@example.com", "User Padrão", new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(8533) },
                    { new Guid("46d1cd7a-c429-46bc-a8c3-26dd7ab60005"), new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(9603), "eskokado@email.com", "Edson Shideki Kokado", new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(9618) },
                    { new Guid("c50b091b-f95d-46e0-b1b8-3bf4fdac0db6"), new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(9630), "mariasilva@email.com", "Maria da Silva", new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(9632) },
                    { new Guid("146bdcb9-5498-43e1-b132-ab522e599d77"), new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(9638), "josesouza@email.com", "José Souza", new DateTime(2021, 6, 10, 9, 5, 16, 971, DateTimeKind.Utc).AddTicks(9641) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Email",
                table: "Players",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stars_GameId",
                table: "Stars",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
