using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListsController : ControllerBase
    {
        private readonly TunifyDbContext _context;

        public PlayListsController(TunifyDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetPlaylists()
        {
          if (_context.Playlists == null)
          {
              return NotFound();
          }
            return await _context.Playlists.ToListAsync();
        }

        // GET: api/PlayLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayList>> GetPlayList(int id)
        {
          if (_context.Playlists == null)
          {
              return NotFound();
          }
            var playList = await _context.Playlists.FindAsync(id);

            if (playList == null)
            {
                return NotFound();
            }

            return playList;
        }

        // PUT: api/PlayLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, PlayList playList)
        {
            if (id != playList.PlayListID)
            {
                return BadRequest();
            }

            _context.Entry(playList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlayLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayList>> PostPlayList(PlayList playList)
        {
          if (_context.Playlists == null)
          {
              return Problem("Entity set 'TunifyDbContext.Playlists'  is null.");
          }
            _context.Playlists.Add(playList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayList", new { id = playList.PlayListID }, playList);
        }

        // DELETE: api/PlayLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }
            var playList = await _context.Playlists.FindAsync(id);
            if (playList == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayListExists(int id)
        {
            return (_context.Playlists?.Any(e => e.PlayListID == id)).GetValueOrDefault();
        }
    }
}
