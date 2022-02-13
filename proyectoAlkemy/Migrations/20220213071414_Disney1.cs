using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoAlkemy.Migrations
{
    public partial class Disney1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharactersMs_Characters_charactersID",
                schema: "disney",
                table: "CharactersMs");

            migrationBuilder.DropForeignKey(
                name: "FK_CharactersMs_MovieSeries_movie_serieID",
                schema: "disney",
                table: "CharactersMs");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSeries_Genres_Genresid",
                schema: "disney",
                table: "MovieSeries");

            migrationBuilder.RenameColumn(
                name: "title",
                schema: "disney",
                table: "MovieSeries",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "release_year",
                schema: "disney",
                table: "MovieSeries",
                newName: "Release_Year");

            migrationBuilder.RenameColumn(
                name: "ranking",
                schema: "disney",
                table: "MovieSeries",
                newName: "Ranking");

            migrationBuilder.RenameColumn(
                name: "image",
                schema: "disney",
                table: "MovieSeries",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Genresid",
                schema: "disney",
                table: "MovieSeries",
                newName: "GenresID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "disney",
                table: "MovieSeries",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieSeries_Genresid",
                schema: "disney",
                table: "MovieSeries",
                newName: "IX_MovieSeries_GenresID");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "disney",
                table: "Genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                schema: "disney",
                table: "Genres",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "asociated_movie_serie",
                schema: "disney",
                table: "Genres",
                newName: "Asociated_Movie_Serie");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "disney",
                table: "Genres",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "movie_serieID",
                schema: "disney",
                table: "CharactersMs",
                newName: "Movie_SerieID");

            migrationBuilder.RenameColumn(
                name: "charactersID",
                schema: "disney",
                table: "CharactersMs",
                newName: "CharactersID");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "disney",
                table: "CharactersMs",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CharactersMs_movie_serieID",
                schema: "disney",
                table: "CharactersMs",
                newName: "IX_CharactersMs_Movie_SerieID");

            migrationBuilder.RenameIndex(
                name: "IX_CharactersMs_charactersID",
                schema: "disney",
                table: "CharactersMs",
                newName: "IX_CharactersMs_CharactersID");

            migrationBuilder.RenameColumn(
                name: "weight",
                schema: "disney",
                table: "Characters",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "disney",
                table: "Characters",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lore",
                schema: "disney",
                table: "Characters",
                newName: "Lore");

            migrationBuilder.RenameColumn(
                name: "image",
                schema: "disney",
                table: "Characters",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "age",
                schema: "disney",
                table: "Characters",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "disney",
                table: "Characters",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharactersMs_Characters_CharactersID",
                schema: "disney",
                table: "CharactersMs",
                column: "CharactersID",
                principalSchema: "disney",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharactersMs_MovieSeries_Movie_SerieID",
                schema: "disney",
                table: "CharactersMs",
                column: "Movie_SerieID",
                principalSchema: "disney",
                principalTable: "MovieSeries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSeries_Genres_GenresID",
                schema: "disney",
                table: "MovieSeries",
                column: "GenresID",
                principalSchema: "disney",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharactersMs_Characters_CharactersID",
                schema: "disney",
                table: "CharactersMs");

            migrationBuilder.DropForeignKey(
                name: "FK_CharactersMs_MovieSeries_Movie_SerieID",
                schema: "disney",
                table: "CharactersMs");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSeries_Genres_GenresID",
                schema: "disney",
                table: "MovieSeries");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "disney",
                table: "MovieSeries",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Release_Year",
                schema: "disney",
                table: "MovieSeries",
                newName: "release_year");

            migrationBuilder.RenameColumn(
                name: "Ranking",
                schema: "disney",
                table: "MovieSeries",
                newName: "ranking");

            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "disney",
                table: "MovieSeries",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "GenresID",
                schema: "disney",
                table: "MovieSeries",
                newName: "Genresid");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "disney",
                table: "MovieSeries",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MovieSeries_GenresID",
                schema: "disney",
                table: "MovieSeries",
                newName: "IX_MovieSeries_Genresid");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "disney",
                table: "Genres",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "disney",
                table: "Genres",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Asociated_Movie_Serie",
                schema: "disney",
                table: "Genres",
                newName: "asociated_movie_serie");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "disney",
                table: "Genres",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Movie_SerieID",
                schema: "disney",
                table: "CharactersMs",
                newName: "movie_serieID");

            migrationBuilder.RenameColumn(
                name: "CharactersID",
                schema: "disney",
                table: "CharactersMs",
                newName: "charactersID");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "disney",
                table: "CharactersMs",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_CharactersMs_Movie_SerieID",
                schema: "disney",
                table: "CharactersMs",
                newName: "IX_CharactersMs_movie_serieID");

            migrationBuilder.RenameIndex(
                name: "IX_CharactersMs_CharactersID",
                schema: "disney",
                table: "CharactersMs",
                newName: "IX_CharactersMs_charactersID");

            migrationBuilder.RenameColumn(
                name: "Weight",
                schema: "disney",
                table: "Characters",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "disney",
                table: "Characters",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Lore",
                schema: "disney",
                table: "Characters",
                newName: "lore");

            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "disney",
                table: "Characters",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Age",
                schema: "disney",
                table: "Characters",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "disney",
                table: "Characters",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharactersMs_Characters_charactersID",
                schema: "disney",
                table: "CharactersMs",
                column: "charactersID",
                principalSchema: "disney",
                principalTable: "Characters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharactersMs_MovieSeries_movie_serieID",
                schema: "disney",
                table: "CharactersMs",
                column: "movie_serieID",
                principalSchema: "disney",
                principalTable: "MovieSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSeries_Genres_Genresid",
                schema: "disney",
                table: "MovieSeries",
                column: "Genresid",
                principalSchema: "disney",
                principalTable: "Genres",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
