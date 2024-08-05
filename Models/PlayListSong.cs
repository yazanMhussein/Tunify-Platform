namespace TunifyPlatform.Models
{
    public class PlayListSong
    {
        public int PlayListSongID { get; set; }

        public int PlayListID { get; set; }
        public PlayList PlayList { get; set; }

        public int SongID { get; set; } 
        public Song Song { get; set; }
        
    }
}
