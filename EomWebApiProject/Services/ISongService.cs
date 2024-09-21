using EomWebApiProject.Models;

public interface ISongService {
    Task<IEnumerable<Song>> GetAllSongsAsync();
    Task<Song> GetSongByIdAsync(int id);
    Task<IEnumerable<Song>> GetSongByGenreAsync (int GenreId);
    Task AddSongAsync(CreateSongDto createSongDto);
    Task<bool> UpdateSongAsync(UpdateSongDto updateSongDto);
    Task<bool> DeleteSongAsync(int id);

    Task<bool> DeleteSongsAsync(IEnumerable<int> songIds);

}