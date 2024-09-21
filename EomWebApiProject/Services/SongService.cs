using EomWebApiProject.Models;

public class SongService : ISongService {
    
    private readonly ISongRepository _songRepository;

    private readonly IConfiguration _configuration;

    private readonly IGenreRepository _genreRepository;

    private readonly ISingerRepository _singerRepository;

    private readonly IAlbumRepository _albumRepository;

    public SongService(ISongRepository songRepository, IGenreRepository genreRepository,
     ISingerRepository singerRepository, IAlbumRepository albumRepository, IConfiguration configuration) {
        _songRepository = songRepository;
        _genreRepository = genreRepository;
        _singerRepository = singerRepository;
        _albumRepository = albumRepository;
        _configuration = configuration;
    }

    public async Task<IEnumerable<Song>> GetAllSongsAsync() {
        return await _songRepository.GetAllSongsAsync();
    }

    public async Task<Song> GetSongByIdAsync (int id) {
        return await _songRepository.GetSongByIdAsync(id) ?? throw new KeyNotFoundException("Song not found");
    }
    
    public async Task<IEnumerable<Song>> GetSongByGenreAsync(int GenreId) {
        var song = await _songRepository.GetSongByGenreAsync(GenreId) ?? throw new KeyNotFoundException("Song not found");
        return song;
    }


    public async Task AddSongAsync(CreateSongDto createSongDTO)
    {
        var song = new Song
        {
            UserName = createSongDTO.UserName,
            MusicName = createSongDTO.MusicName,
            GenreId = createSongDTO.GenreId,
            ReleaseDate = createSongDTO.ReleaseDate,
            PublishDate = createSongDTO.PublishDate,
            ImagePath = createSongDTO.ImageFile != null ? SaveFile(createSongDTO.ImageFile) : null,
            MusicPath = SaveFile(createSongDTO.MusicFile),
            Lyrics = createSongDTO.Lyrics,
            Review = createSongDTO.Review,
            Tag = createSongDTO.Tag,
            Slug = createSongDTO.Slug,
            AlbumId = createSongDTO.AlbumId,
        };

        await _songRepository.AddSongAsync(song);
    }


    private string SaveFile(IFormFile file)

    {
        string directoryPath;

        if (file.ContentType.StartsWith("image/")) {
            directoryPath = _configuration["FileSettings:ImageFilesPath"];
        } else {
            directoryPath = _configuration["FileSettings:SongFilesPath"];
        }

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        var filePath = Path.Combine(directoryPath, file.FileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyToAsync(stream).Wait();
        return filePath;

    }

    public async Task<bool> UpdateSongAsync(UpdateSongDto updateSongDto){
        var existingSong = await _songRepository.GetSongByIdAsync(updateSongDto.Id);
        ArgumentNullException.ThrowIfNull(existingSong);

        existingSong.MusicName = updateSongDto.MusicName;
        existingSong.GenreId = updateSongDto.GenreId;
        existingSong.AlbumId = updateSongDto.AlbumId;

        return await _songRepository.UpdateSongAsync(existingSong);
    }


    public async Task<bool> DeleteSongAsync(int id) {
        var song = await _songRepository.GetSongByIdAsync(id);
        if (song == null) {
            throw new ArgumentNullException(nameof(song));
        }
        return await _songRepository.DeleteSongAsync(id);
    }

    public async Task<bool> DeleteSongsAsync(IEnumerable<int> songIds) {
        return await _songRepository.DelteSongsAsync(songIds);
    }

}