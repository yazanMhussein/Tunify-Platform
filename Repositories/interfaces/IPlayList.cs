using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IPlayList
    {
        Task<PlayList> CreatePlayList(PlayList playList);
        Task<List<PlayList>> GetAllPlayList();
        Task<PlayList> GetPlayListById(int playListId);
        Task<PlayList> UpdatePlayList(int id, PlayList playList); 
        Task<IEnumerable<Song>> GetSongsForPlaylist(int playlistId);
        Task<bool> AddSongToPlaylist(int playListId, int songId);
        Task DeletePlayList(int id);
    }
} 
