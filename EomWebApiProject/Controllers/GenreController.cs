using EomWebApiProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
// using System.Web.http


[Route("api/[controller]")]
[ApiController]
[Consumes("application/json")]
[EnableCors("AllowSpecificOrigin")]
public class GenreController : ControllerBase {
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreRepository) {
        _genreService = genreRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> GetGenreAsync() {
        var genres = await _genreService.GetGnereAsync();
        return Ok(genres);
    }

    [HttpPost]
    public async Task<IActionResult> AddGenreAsync([FromBody] Genre genre) {
        if (genre == null) {
            return BadRequest("Song data is null.");
        }
        
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        try {
            await _genreService.AddGenreAsync(genre);
            return Ok("it's added");
            // return CreatedAtAction(nameof(GetSongByIdAsync), new { id = song.Id }, song);
        }
        catch (Exception ex) {
            Console.WriteLine("Caught" + ex.Message);
            Console.WriteLine("Inner Exception" + ex.InnerException.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");


    }
    }

}