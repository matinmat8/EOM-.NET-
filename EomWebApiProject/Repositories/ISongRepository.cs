using EomWebApiProject.Models;

public interface ISongRepository {

    // CRUD Operations

    Task<Song> GetSongByIdAsync(int id);
    Task AddSongAsync(Song song);
    Task<bool> UpdateSongAsync(Song song);
    Task<bool> DeleteSongAsync(int id);


    Task<bool> DelteSongsAsync(IEnumerable<int> songIds);
    Task<IEnumerable<Song>> GetAllSongsAsync();
    Task<IEnumerable<Song>> GetSongByGenreAsync (int GenreId);

}