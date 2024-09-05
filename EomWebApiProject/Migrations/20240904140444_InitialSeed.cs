using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EomWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreDiscription", "GenreName" },
                values: new object[,]
                {
                    { 3, null, "Rock" },
                    { 4, null, "Pop" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "AlbumName", "GenreId", "ReleaseDate", "SingerId", "TrackCount" },
                values: new object[,]
                {
                    { 3, "Album1", 4, new DateOnly(2023, 2, 1), null, 10 },
                    { 4, "Album2", 3, new DateOnly(2020, 2, 1), null, 12 }
                });

            migrationBuilder.InsertData(
                table: "Singers",
                columns: new[] { "Id", "AboutSinger", "Birth", "Death", "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateOnly(1980, 1, 1), null, 3, "Drake" },
                    { 2, null, new DateOnly(1990, 1, 1), null, 4, "Moein" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "GenreId", "ImagePath", "Lyrics", "MusicName", "MusicPath", "PublishDate", "ReleaseDate", "Review", "Slug", "Tag", "UserName", "Views" },
                values: new object[,]
                {
                    { 1, 3, 3, null, null, "Be mine", "path/to/song1.mp3", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2022, 2, 1), null, null, null, "Matin", 0 },
                    { 2, 4, 4, null, null, "Song2", "path/to/song2.mp3", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2020, 2, 1), null, null, null, "user2", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Singers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Singers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
