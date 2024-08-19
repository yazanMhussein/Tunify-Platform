using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IArtist
    { 
        Task<Artist> CreateArtists(Artist artist);
        Task<List<Artist>> GetAllArtists();
        Task<Artist> GetArtistsById(int artistId);
        Task<Artist> UpdateArtists(int id, Artist artist);
        Task<bool> AddSongToArtist(int artistId, int songId);
        Task<ICollection<Song>> GetSongsForArtist(int artistId);
        Task DeleteArtists(int id);
        
    }
}
