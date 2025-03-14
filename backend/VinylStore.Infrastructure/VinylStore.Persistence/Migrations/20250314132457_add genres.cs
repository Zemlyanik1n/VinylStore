using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinylStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addgenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumEntityGenreEntity_Albums_AlbumEntityId",
                table: "AlbumEntityGenreEntity");

            migrationBuilder.RenameColumn(
                name: "AlbumEntityId",
                table: "AlbumEntityGenreEntity",
                newName: "AlbumsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumEntityGenreEntity_Albums_AlbumsId",
                table: "AlbumEntityGenreEntity",
                column: "AlbumsId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumEntityGenreEntity_Albums_AlbumsId",
                table: "AlbumEntityGenreEntity");

            migrationBuilder.RenameColumn(
                name: "AlbumsId",
                table: "AlbumEntityGenreEntity",
                newName: "AlbumEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumEntityGenreEntity_Albums_AlbumEntityId",
                table: "AlbumEntityGenreEntity",
                column: "AlbumEntityId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
