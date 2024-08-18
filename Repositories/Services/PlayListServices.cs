using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlayListServices : IPlayList
    {
        private readonly TunifyDbContext _context;

        public PlayListServices(TunifyDbContext context)
        {
            _context = context; 
        }
        public async Task<PlayList> CreatePlayList(PlayList playList)
        {
            _context.Playlists.Add(playList);
            await _context.SaveChangesAsync();
            return playList;
        }
        public async Task<List<PlayList>> GetAllPlayList()
        {
            var allPlayList = await _context.Playlists.ToListAsync();
            return allPlayList;
        }
        public async Task<PlayList> GetPlayListById(int playListId)
        {
            var playlist = await _context.Playlists.FindAsync(playListId);
            return playlist;
        }
        public async Task<PlayList> UpdatePlayList(int id, PlayList playList)
        {
            _context.Playlists.Entry(playList).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return playList;
        }
        public async Task DeletePlayList(int id)
        {
            var getPlayList = await GetPlayListById(id);
            _context.Playlists.Remove(getPlayList);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> AddSongToPlaylist(int playListId, int songId) 
        {
            var playlist = await _context.PlayLists.FindAsync(playListId);
            var song = await _context.Songs.FindAsync(songId);

            if (playlist == null || song == null) { return false; }
            
                playlist.PlaylistSongs.Add(new PlaylistSong { PlaylistID = playListId, SongID = songId });
                await _context.SaveChangesAsync();
                return true;
            

        }
    }
}
