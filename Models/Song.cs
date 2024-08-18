namespace TunifyPlatform.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; } 


        // ForeignKey ID AND Class
        public int ArtistID { get; set; } 
        public Artist Artist { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }
        

        // this a collection of two different class put into one clas as is a model with the properties defined in a ERD
        public ICollection<PlayListSong> PlayListSong { get; set; }

    }
}
