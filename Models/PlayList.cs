namespace TunifyPlatform.Models
{
    public class PlayList
    {
        public int PlayListID { get; set; } 
        public string Playlist_Name { get; set; }
        public DateTime Created_Date { get; set; }

        // ForeignKey ID AND Class
        public int UserID { get; set; }
        public User User { get; set; }

        // this a collection of two different class put into one clas as is a model with the properties defined in a ERD
       public ICollection<PlayListSong> PlayListSong { get; set; }
    }
}
