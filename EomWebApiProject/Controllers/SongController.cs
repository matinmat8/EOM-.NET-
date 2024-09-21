
using EomWebApiProject.Models;
using Microsoft.AspNetCore.Mvc;




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
public async Task<IActionResult> GetSongByIdAsync(int id) {
    var song = await _songService.GetSongByIdAsync(id);

    if (song == null) {
        return NotFound();
    }
    return Ok(song);
    }


    [HttpGet("download/{songId}")]
    public async Task<IActionResult> GetSongFile(int songId) {
        var song = await _songService.GetSongByIdAsync(songId);
        if (!System.IO.File.Exists(song.MusicPath)) {
            return NotFound();
            }
        var fileBytes = await System.IO.File.ReadAllBytesAsync(song.MusicPath);
            return File(fileBytes, "audio/mpeg");
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
    public async Task<IActionResult> AddSongAsync([FromForm] CreateSongDto createSongDto) {
        if (createSongDto == null) {
            return BadRequest("Song data is null.");
        }
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            await _songService.AddSongAsync(createSongDto);
            return Ok("song added");
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSongAsync([FromBody] UpdateSongDto updateSongDto) {
        if (updateSongDto == null) {
            return BadRequest("song data is null");
        }
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            await _songService.UpdateSongAsync(updateSongDto);
            return Ok("It's updated");
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