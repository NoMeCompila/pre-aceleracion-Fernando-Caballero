using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoAlkemy.Migrations
{
    public partial class nullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSeries_Genres_GenresID",
                table: "MovieSeries");

            migrationBuilder.AlterColumn<int>(
                name: "GenresID",
                table: "MovieSeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSeries_Genres_GenresID",
                table: "MovieSeries",
                column: "GenresID",
                principalTable: "Genres",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSeries_Genres_GenresID",
                table: "MovieSeries");

            migrationBuilder.AlterColumn<int>(
                name: "GenresID",
                table: "MovieSeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSeries_Genres_GenresID",
                table: "MovieSeries",
                column: "GenresID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
