using System.Resources;
using System.Runtime.CompilerServices;
using EomWebApiProject.Models;
using Microsoft.AspNetCore.Mvc;




[Route("api/[controller]")]
[ApiController]
public class SingerController : ControllerBase {

    private readonly ISingerService _singerService;

    
    public SingerController(ISingerService singerService) {
        _singerService = singerService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Singer>>> GetAllSingersAsync () {
        var singers = await _singerService.GetAllSingersAsync();
        return Ok(singers);
    }


    [HttpGet("{singerId}")]
    public async Task<ActionResult<Singer>> GetSingerByIdAsync(int singerId) {
        var singer = await _singerService.GetSingerByIdAsync(singerId);
        return Ok(singer);
    }


    [HttpPost]
    public async Task<ActionResult> AddSingerAsync([FromBody] CreateSingerDto createSingerDto) {
        if (createSingerDto == null) {
            return BadRequest("Singer Data Is Null");
        }
        try {
            await _singerService.AddSingerAsync(createSingerDto);
            return Ok("Singer Added");
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateSingerAsync([FromBody] UpdateSingerDto updateSingerDto) {
        if (updateSingerDto == null) {
            return BadRequest("Data Is Null");
        }
        try {
            await _singerService.UpdateSingerAsync(updateSingerDto);
            return Ok("Singer Updated");
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpDelete("{singerId}")]
    public async Task<ActionResult> DeleteSingerAsync(int singerId) {
        if (singerId == 0) {
            return BadRequest("No Singer ID Provided");
        }
        try {
            await _singerService.DeleteSingerAsync(singerId);
            return Ok("Got Deleted");
        }
        catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");;
        }
    }

}