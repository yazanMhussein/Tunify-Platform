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
    public class PlayListsController : ControllerBase
    {
        private readonly IPlayList _playlist;

        public PlayListsController(IPlayList context)
        {
            _playlist = context;
        }

        // GET: api/PlayLists
        [Route("/PlayList/GetAllPlayList")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetPlaylists()
        {
         return await _playlist.GetAllPlayList();
        }

        // GET: api/PlayLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayList>> GetPlayList(int id)
        {
          return await _playlist.GetPlayListById(id);
        }

        // PUT: api/PlayLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, PlayList playList)
        {
            var updatePlayList = await _playlist.UpdatePlayList(id, playList);
            return Ok(updatePlayList);
        }

        // POST: api/PlayLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayList>> PostPlayList(PlayList playList)
        {
            var NewPlayList = await _playlist.CreatePlayList(playList);
            return Ok(NewPlayList);
        }

        // DELETE: api/PlayLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
         var deletedPlayList = _playlist.DeletePlayList(id);
            return Ok();   
        }
        
    }
}
