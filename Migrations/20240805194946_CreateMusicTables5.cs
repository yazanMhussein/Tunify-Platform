using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class CreateMusicTables5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistID", "Bio", "Name" },
                values: new object[] { 3, "he is always sign about people who are try to code better then him and he doesn't like it", "coder" });

            migrationBuilder.InsertData(
                table: "Subscripitions",
                columns: new[] { "SubscripitionID", "Price", "Subscription_Type" },
                values: new object[] { 3, 20, "Premium" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumID", "Album_Name", "ArtistID", "Release_Date" },
                values: new object[] { 3, "coding hard", 3, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Join_Date", "SubscripitionID", "Username" },
                values: new object[] { 3, "coding.studying@gmial.com", new DateTime(1991, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "coding boy" });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlayListID", "Created_Date", "Playlist_Name", "UserID" },
                values: new object[] { 3, new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "coding music", 3 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongID", "AlbumID", "ArtistID", "Durtion", "Genre", "Title" },
                values: new object[] { 3, 3, 3, new TimeSpan(0, 0, 8, 10, 0), "r&b", "coding hard " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlayListID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subscripitions",
                keyColumn: "SubscripitionID",
                keyValue: 3);
        }
    }
}
