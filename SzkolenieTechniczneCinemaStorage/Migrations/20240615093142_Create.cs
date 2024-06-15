using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczneCinemaStorage.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cinema");

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                schema: "Cinema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                schema: "Cinema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TimeMinutes = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_MovieCategories_MovieCategoryId",
                        column: x => x.MovieCategoryId,
                        principalSchema: "Cinema",
                        principalTable: "MovieCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                schema: "Cinema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    SeanceId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Cinema",
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalSchema: "Cinema",
                        principalTable: "Seances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "Cinema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    SeanceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalSchema: "Cinema",
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_MovieId",
                schema: "Cinema",
                table: "MovieCategories",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieCategoryId",
                schema: "Cinema",
                table: "Movies",
                column: "MovieCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_MovieId",
                schema: "Cinema",
                table: "Seances",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_SeanceId",
                schema: "Cinema",
                table: "Seances",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeanceId",
                schema: "Cinema",
                table: "Tickets",
                column: "SeanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategories_Movies_MovieId",
                schema: "Cinema",
                table: "MovieCategories",
                column: "MovieId",
                principalSchema: "Cinema",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategories_Movies_MovieId",
                schema: "Cinema",
                table: "MovieCategories");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "Cinema");

            migrationBuilder.DropTable(
                name: "Seances",
                schema: "Cinema");

            migrationBuilder.DropTable(
                name: "Movies",
                schema: "Cinema");

            migrationBuilder.DropTable(
                name: "MovieCategories",
                schema: "Cinema");
        }
    }
}
