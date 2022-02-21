using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoAlkemy.Migrations
{
    public partial class navegacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersMs",
                schema: "disney");

            migrationBuilder.RenameTable(
                name: "MovieSeries",
                schema: "disney",
                newName: "MovieSeries");

            migrationBuilder.RenameTable(
                name: "Genres",
                schema: "disney",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Characters",
                schema: "disney",
                newName: "Characters");

            migrationBuilder.CreateTable(
                name: "CharactersMovieSerie",
                columns: table => new
                {
                    CharactersID = table.Column<int>(type: "int", nullable: false),
                    MovieSeriesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMovieSerie", x => new { x.CharactersID, x.MovieSeriesID });
                    table.ForeignKey(
                        name: "FK_CharactersMovieSerie_Characters_CharactersID",
                        column: x => x.CharactersID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersMovieSerie_MovieSeries_MovieSeriesID",
                        column: x => x.MovieSeriesID,
                        principalTable: "MovieSeries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMovieSerie_MovieSeriesID",
                table: "CharactersMovieSerie",
                column: "MovieSeriesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersMovieSerie");

            migrationBuilder.EnsureSchema(
                name: "disney");

            migrationBuilder.RenameTable(
                name: "MovieSeries",
                newName: "MovieSeries",
                newSchema: "disney");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genres",
                newSchema: "disney");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Characters",
                newSchema: "disney");

            migrationBuilder.CreateTable(
                name: "CharactersMs",
                schema: "disney",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharactersID = table.Column<int>(type: "int", nullable: false),
                    Movie_SerieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharactersMs_Characters_CharactersID",
                        column: x => x.CharactersID,
                        principalSchema: "disney",
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersMs_MovieSeries_Movie_SerieID",
                        column: x => x.Movie_SerieID,
                        principalSchema: "disney",
                        principalTable: "MovieSeries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMs_CharactersID",
                schema: "disney",
                table: "CharactersMs",
                column: "CharactersID");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMs_Movie_SerieID",
                schema: "disney",
                table: "CharactersMs",
                column: "Movie_SerieID");
        }
    }
}
