using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoAlkemy.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "disney");

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "disney",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    lore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CharactersMs",
                schema: "disney",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characters_ms = table.Column<int>(type: "int", nullable: false),
                    movie_serie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "disney",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    asociated_movie_serie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CharactersCharactersMS",
                schema: "disney",
                columns: table => new
                {
                    Charactersid = table.Column<int>(type: "int", nullable: false),
                    movies_seriesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersCharactersMS", x => new { x.Charactersid, x.movies_seriesid });
                    table.ForeignKey(
                        name: "FK_CharactersCharactersMS_Characters_Charactersid",
                        column: x => x.Charactersid,
                        principalSchema: "disney",
                        principalTable: "Characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersCharactersMS_CharactersMs_movies_seriesid",
                        column: x => x.movies_seriesid,
                        principalSchema: "disney",
                        principalTable: "CharactersMs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieSeries",
                schema: "disney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ranking = table.Column<int>(type: "int", nullable: false),
                    Genresid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieSeries_Genres_Genresid",
                        column: x => x.Genresid,
                        principalSchema: "disney",
                        principalTable: "Genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharactersMSMovieSerie",
                schema: "disney",
                columns: table => new
                {
                    Charactersid = table.Column<int>(type: "int", nullable: false),
                    movies_serieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMSMovieSerie", x => new { x.Charactersid, x.movies_serieId });
                    table.ForeignKey(
                        name: "FK_CharactersMSMovieSerie_CharactersMs_Charactersid",
                        column: x => x.Charactersid,
                        principalSchema: "disney",
                        principalTable: "CharactersMs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersMSMovieSerie_MovieSeries_movies_serieId",
                        column: x => x.movies_serieId,
                        principalSchema: "disney",
                        principalTable: "MovieSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharactersCharactersMS_movies_seriesid",
                schema: "disney",
                table: "CharactersCharactersMS",
                column: "movies_seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMSMovieSerie_movies_serieId",
                schema: "disney",
                table: "CharactersMSMovieSerie",
                column: "movies_serieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSeries_Genresid",
                schema: "disney",
                table: "MovieSeries",
                column: "Genresid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersCharactersMS",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "CharactersMSMovieSerie",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "CharactersMs",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "MovieSeries",
                schema: "disney");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "disney");
        }
    }
}
