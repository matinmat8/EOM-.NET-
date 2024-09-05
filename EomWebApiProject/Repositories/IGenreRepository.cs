using EomWebApiProject.Models;

public interface IGenreRepository {
    Task<IEnumerable<Genre>> GetGnereAsync();
    Task AddGenreAsync(Genre genre);
}