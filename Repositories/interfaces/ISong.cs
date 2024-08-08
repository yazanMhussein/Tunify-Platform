using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface ISong
    {
        Task<Song> CreateSongs(Song song);
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSongsById(int songId); 
        Task<Song> UpdateSongs(int id, Song song);
        Task DeleteSongs(int id);
    }
}
