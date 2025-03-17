using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinylStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumEntityGenreEntity_Albums_AlbumId1",
                table: "AlbumEntityGenreEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumEntityGenreEntity_Genres_GenreId1",
                table: "AlbumEntityGenreEntity");

            migrationBuilder.DropIndex(
                name: "IX_AlbumEntityGenreEntity_AlbumId1",
                table: "AlbumEntityGenreEntity");

            migrationBuilder.DropIndex(
                name: "IX_AlbumEntityGenreEntity_GenreId1",
                table: "AlbumEntityGenreEntity");

            migrationBuilder.DropColumn(
                name: "AlbumId1",
                table: "AlbumEntityGenreEntity");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "AlbumEntityGenreEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AlbumId1",
                table: "AlbumEntityGenreEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GenreId1",
                table: "AlbumEntityGenreEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumEntityGenreEntity_AlbumId1",
                table: "AlbumEntityGenreEntity",
                column: "AlbumId1");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumEntityGenreEntity_GenreId1",
                table: "AlbumEntityGenreEntity",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumEntityGenreEntity_Albums_AlbumId1",
                table: "AlbumEntityGenreEntity",
                column: "AlbumId1",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumEntityGenreEntity_Genres_GenreId1",
                table: "AlbumEntityGenreEntity",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
