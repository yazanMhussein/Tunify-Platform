using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Identity.Client;
using TunifyPlatform.Models;

namespace TunifyPlatform.Data
{
    public class TunifyDbContext : DbContext
    {
        public TunifyDbContext(DbContextOptions<TunifyDbContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<PlayList> Playlists { get; set; }
        public DbSet<Subscripition> Subscripitions { get; set; }
        public DbSet<PlayListSong> PlaylistsSong { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // here I add Entity and Seed Data
            base.OnModelCreating(modelBuilder);

            // this is where i have im two group(PlayList, Song) in one group(PlayListSong)
            //  Configures a composite primary key for the `PlaylistSong` junction table.
            modelBuilder.Entity<PlayListSong>().HasKey(pk => new { pk.PlayListID, pk.SongID });
            
            
            // Many to Many Relationship between Playlist and Song Model Entity
            modelBuilder.Entity<PlaylistsSong>()
                .HasOne(ps => ps.PlayList) 
                .WithMany(ps => ps.PlayListSong)
                .HasForeignKey(ps => ps.PlayListID);

            modelBuilder.Entity<PlaylistsSong)()
                .HasOne(ps => ps.Song)
                .WithMany(ps => ps.PlayListSong)
                .HasForeignKey(ps => ps.SongID);

            // One to Many Relationship between Artist and Song
            modelBuilder.Entity<Songs>()
                .HasOne(s => s.Artist) // specifies that each `Song` has one `Artist
                .WithMany(s => ps.Songs)// specifies that each `Artist` can have many `Songs
                .HasForeignKey(s => s.ArtistID); // defines the foreign key in the `Song` table

            // One to Many Relationship between Album and Song
            modelBuilder.Entity<Songs>()
                .HasOne(s => s.Album) // specifies that each `Song` has one `Album
                .WithMany(a => a.Songs) // specifies that each `Album` can have many `Songs
                .HasForeignKey(s => s.AlbumID); // defines the foreign key in the `Song` table


            // key Entity
            modelBuilder.Entity<User>().HasKey(pk => pk.UserID);
            modelBuilder.Entity<Song>().HasKey(pk => pk.SongID);
            modelBuilder.Entity<PlayList>().HasKey(pk => pk.PlayListID);
            modelBuilder.Entity<Subscripition>().HasKey(pk => pk.SubscripitionID);
            modelBuilder.Entity<Artist>().HasKey(pk => pk.ArtistID);
            modelBuilder.Entity<Album>().HasKey(pk => pk.AlbumID);

            //Seed data
            modelBuilder.Entity<User>().HasData(
              new User { UserID = 1, Username = "frog man", Email = "bluewind@gmial.com", Join_Date = new DateTime(2020, 1, 1), SubscripitionID = 1 },
              new User { UserID = 2, Username = "flying boy", Email = "dreamwive@gmial.com", Join_Date = new DateTime(2021, 2, 15), SubscripitionID = 2 },
              new User { UserID = 3, Username = "coding boy", Email = "coding.studying@gmial.com", Join_Date = new DateTime(1991, 6, 27), SubscripitionID = 3 }
          );

            modelBuilder.Entity<Song>().HasData(
                new Song { SongID = 1, Title = "black litte don't give up to soon son", Durtion = new TimeSpan(0, 3, 45), Genre = "Pop", AlbumID = 1, ArtistID = 1 },
                new Song { SongID = 2, Title = "gold digger: why is everything about! yeah ", Durtion = new TimeSpan(0, 4, 20), Genre = "r&b", AlbumID = 2, ArtistID = 2 },
                new Song { SongID = 3, Title = "coding hard ", Durtion = new TimeSpan(0, 8, 10), Genre = "r&b", AlbumID = 3, ArtistID = 3 }
            );

            modelBuilder.Entity<PlayList>().HasData(
                new PlayList { PlayListID = 1, Playlist_Name = "Hits", Created_Date = new DateTime(2022, 5, 1), UserID = 1 },
                new PlayList { PlayListID = 2, Playlist_Name = "Favorites", Created_Date = new DateTime(2022, 6, 15), UserID = 2 },
                new PlayList { PlayListID = 3, Playlist_Name = "coding music", Created_Date = new DateTime(2024, 6, 27), UserID = 3 }
            );

            modelBuilder.Entity<Subscripition>().HasData(
                new Subscripition { SubscripitionID = 1, Subscription_Type = "Basic", Price = 10 },
                new Subscripition { SubscripitionID = 2, Subscription_Type = "Premium", Price = 20 },
                new Subscripition { SubscripitionID = 3, Subscription_Type = "Premium", Price = 20 }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistID = 1, Name = "Black litte", Bio = "sing about how hard life is and why you should never give up" },
                new Artist { ArtistID = 2, Name = "gold digger", Bio = "he is always sign about people who are try to be his friend but they are really far his money" },
                new Artist { ArtistID = 3, Name = "coder", Bio = "he is always sign about people who are try to code better then him and he doesn't like it" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumID = 1, Album_Name = "Greatest Hits", Release_Date = new DateTime(2020, 1, 1), ArtistID = 1 },
                new Album { AlbumID = 2, Album_Name = "Classic Collection", Release_Date = new DateTime(2021, 2, 15), ArtistID = 2 },
                new Album { AlbumID = 3, Album_Name = "coding hard", Release_Date = new DateTime(2024, 8, 5), ArtistID = 3 }
            );
        }
        Migration Migration { get; set; }
    }
}
