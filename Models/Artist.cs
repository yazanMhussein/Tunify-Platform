namespace TunifyPlatform.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        // I'm now connect my song and artist togetter 
        // Collection of Songs (One-to-Many Relationship)
        public ICollection<Song> Songs { get; set; }
    }
}
