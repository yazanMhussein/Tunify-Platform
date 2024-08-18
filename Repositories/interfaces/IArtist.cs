using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IArtist
    { 
        Task<Artist> CreateArtists(Artist artist);
        Task<List<Artist>> GetAllArtists();
        Task<Artist> GetArtistsById(int artistId);
        Task<Artist> UpdateArtists(int id, Artist artist);
        Task<bool<Artist>> AddSongToArtist(int artistId, int songId);
        Task DeleteArtists(int id);
    }
}
