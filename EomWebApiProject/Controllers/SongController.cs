
using EomWebApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


[Route("api/[controller]")]
[ApiController]
public class SongController : ControllerBase {

    private readonly ISongService _songService;
    public SongController(ISongService songService) {
        _songService = songService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Song>>> GetAllSongs()
    {
        var songs = await _songService.GetAllSongsAsync();
        return Ok(songs);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Song>> GetSongByIdAsync(int id) {
        try {
            var song = await _songService.GetSongByIdAsync(id);
            return Ok(song);
        }
        catch (KeyNotFoundException) {
            return NotFound();
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(("genre/{GenreId}"))]
    public async Task<IActionResult> GetSongByGenreAsync(int GenreId) {
        try {
        var songs = await _songService.GetSongByGenreAsync(GenreId);
        return Ok(songs);
        }
        catch (KeyNotFoundException) {
            return NotFound();
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddSongAsync([FromBody] Song song) {
        if (song == null) {
            return BadRequest("Song data is null.");
        }
        
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        try {
            await _songService.AddSongAsync(song);
            return CreatedAtAction(nameof(GetSongByIdAsync), new { id = song.Id }, song);
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSongAsync(int id ,[FromBody] Song song) {
        if (song == null) {
            return BadRequest("song data is null");
        }
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        if (id != song.Id) {
            return BadRequest("Song ID Mismatch");
        }
        try {
            await _songService.UpdateSongAsync(song);
            return NoContent();
        }
        catch (KeyNotFoundException) {
            return NotFound("Song not found");
    }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpDelete("{songId}")]
    public async Task<IActionResult> DeleteSongAsync( int songId ) {
        if (songId == 0) {
            return BadRequest("No Song ID Provided");
        } 
        await _songService.DeleteSongAsync(songId);
        return Ok("Song got deleted");
    }

    [HttpDelete("batch")]
    public async Task<IActionResult> DelteSongsAsync ( [FromBody] IEnumerable<int> songIds ) {
        if (songIds == null || !songIds.Any()) {
            return BadRequest("No Song IDs Provided");
        }
        await _songService.DeleteSongsAsync(songIds);
        return Ok("Songs got deleted");
    }
}