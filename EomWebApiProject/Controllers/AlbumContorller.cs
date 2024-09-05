using EomWebApiProject.Models;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase {

    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService) {
        _albumService = albumService;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Album>> GetAlbumByIdAsync(int id) {
        var album = await _albumService.GetAlbumByIdAsync(id);
        return Ok(album);
    }


    [HttpPost]
    public async Task<ActionResult> AddAlbumAsync ( [FromBody] Album album) {
        if (album == null) {
            return BadRequest("Album data is null");
        } 

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        try {
            await _albumService.AddAlbumAsync(album);
            return Ok("It's added");
            // return CreatedAtAction(nameof(GetAlbumByIdAsync), new { id = album.Id }, album);
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("{albumId}/songs")]
    public async Task<ActionResult> AddSongsToAlbumAsync(int albumId, [FromBody] List<Song> songs) {
        if (songs == null) {
            return BadRequest("There is no data, Null Data Error");
        }
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            await _albumService.AddSongsToAlbumAsync(albumId, songs);
            return Ok();
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    } 
}