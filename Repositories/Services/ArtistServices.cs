using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class ArtistServices : IArtist
    {
        private readonly TunifyDbContext _context;

        public ArtistServices(TunifyDbContext context)
        {
            _context = context; 
        }

        public async Task<Artist> CreateArtists(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
        public async Task<List<Artist>> GetAllArtists()
        {
            var allArtist = await _context.Artists.ToListAsync();
            return allArtist;
        }

        public async Task<Artist> GetArtistsById(int artistId)
        {
            var artist = await _context.Artists.FindAsync(artistId);
            return artist;
        }

        public async Task<Artist> UpdateArtists(int id, Artist artist)
        {
            _context.Artists.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return artist;
        }
        public async Task DeleteArtists(int id)
        {
            var getArtist = await GetArtistsById(id);
            _context.Artists.Remove(getArtist);
            await _context.SaveChangesAsync();
        }
    }
}
 