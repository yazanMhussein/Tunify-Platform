using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IPlayList
    {
        Task<PlayList> CreatePlayList(PlayList playList);
        Task<List<PlayList>> GetAllPlayList();
        Task<PlayList> GetPlayListById(int playListId);
        Task<PlayList> UpdatePlayList(int id, PlayList playList); 
        Task DeletePlayList(int id);
    }
} 
