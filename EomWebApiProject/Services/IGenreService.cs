using EomWebApiProject.Models;

public interface IGenreService {

    Task<IEnumerable<Genre>> GetGnereAsync();
    Task AddGenreAsync(Genre genre);

}