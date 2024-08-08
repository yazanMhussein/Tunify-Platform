using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISong _song;

        public SongsController(ISong context)
        {
            _song = context;
        }

        // GET: api/Songs
        [Route("/Songs/GetAllSongs")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _song.GetAllSongs();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            return await _song.GetSongsById(id);
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            var updateSong = await _song.UpdateSongs(id, song);
            return Ok(updateSong);
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            var NewSong = await _song.CreateSongs(song);
            return Ok(NewSong);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var deletedSong = _song.DeleteSongs(id);
            return Ok();
        }
    }
}
