using EomWebApiProject.Models;
// using EomWebApiProject.Data;


public class GenreService : IGenreService {
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository) {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Genre>> GetGnereAsync() {
        return await _genreRepository.GetGnereAsync();
    }

    public async Task AddGenreAsync(Genre genre) {
        ArgumentNullException.ThrowIfNull(genre);

        var genreToAdd = new Genre {
            Id = genre.Id,
            GenreName = genre.GenreName,
            GenreDiscription = genre.GenreDiscription,
            Singers = genre.Singers,
            Songs = genre.Songs,
            Albums = genre.Albums,
            PlayLists = genre.PlayLists,


        };
        await _genreRepository.AddGenreAsync(genreToAdd);


    }
}