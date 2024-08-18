using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TunifyPlatform.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Album_Name { get; set; }
        public DateTime Release_Date { get; set; }

        //ForeignKey ID AND Class
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; set; }


    }
}
