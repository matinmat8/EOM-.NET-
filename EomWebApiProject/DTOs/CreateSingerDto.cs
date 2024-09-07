
public class CreateSingerDto {
    
    public int Id { get; set; }

    public string Name{ get; set; }
    public int GenreId { get; set; }
    public int AlbumId { get; set; }
    public DateOnly? Birth { get; set; }
    public DateOnly? Death { get; set; }
    public string? AboutSinger { get; set; }

    }
