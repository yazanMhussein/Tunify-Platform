using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class SongServices : ISong
    {
        private readonly TunifyDbContext _context;

        public SongServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Song> CreateSongs(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }



        public async Task<List<Song>> GetAllSongs()
        {
            var allSong = await _context.Songs.ToListAsync();
            return allSong;
        }

        public async Task<Song> GetSongsById(int songId)
        {
            var song = await _context.Songs.FindAsync(songId);
            return song;
        }

        public async Task<Song> UpdateSongs(int id, Song song)
        {
            _context.Songs.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return song;
        }
        
        public async Task DeleteSongs(int id)
        {
            var getSong = await GetSongsById(id);
            _context.Songs.Remove(getSong);
            await _context.SaveChangesAsync();
        }
    }
}
