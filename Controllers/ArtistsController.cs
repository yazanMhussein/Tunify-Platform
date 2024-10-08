﻿using System;
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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _artist;

        public ArtistsController(IArtist context)
        {
            _artist = context;
        }

        // GET: api/Artists
        [Route("/Artist/GetAllArtists")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
         return await _artist.GetAllArtists();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
          return await _artist.GetArtistsById(id);
        }


        // GET: api/Artists/{artistId}/Songs
        [HttpGet("{artistId}/Songs")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsForArtist(int artistId)
        {
            var songs = await _artist.GetSongsForArtist(artistId);
            return Ok(songs);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
           var updateArtist = await _artist.UpdateArtists(id, artist);
           return Ok(updateArtist); 
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
          var NewArtist = await _artist.CreateArtists(artist);
            return Ok(NewArtist);
        }
         
        // POST: api/Artists/{artistId}/Songs/{songId}
        [HttpPost("artists/{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            var result = await _artist.AddSongToArtist(artistId, songId);
            if (result)
                return Ok();
            else
                return BadRequest("Failed to add the song to the artist.");
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
          var deletedArtist = _artist.DeleteArtists(id);
            return Ok();
        }
    }
}
