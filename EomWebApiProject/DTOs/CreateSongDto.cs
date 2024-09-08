public class CreateSongDto
{
    public string UserName { get; set; }
    public string MusicName { get; set; }
    public int GenreId { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public DateTime? PublishDate { get; set; }
    public IFormFile? ImageFile { get; set; }
    public IFormFile MusicFile { get; set; }
    public string? Lyrics { get; set; }
    public string? Review { get; set; }
    public string? Tag { get; set; }
    public string? Slug { get; set; }
    public int AlbumId { get; set; }
    // public List<int> SingerIds { get; set; }
}
