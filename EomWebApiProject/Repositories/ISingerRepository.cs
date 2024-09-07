using EomWebApiProject.Models;


public interface ISingerRepository {
  
    Task<IEnumerable<Singer>> GetAllSingersAsync();
  
    Task<Singer> GetSingerByIdAsync(int singerId);
  
    Task AddSingerAsync(Singer singer);

    Task<bool> UpdateSingerAsync(Singer singer);
    Task<bool> DeleteSingerAsync(int singerId);

    // Task 
    
    
    // Task<IEnumerable<Singer>> SearchSingersAsync(string searchTerm);
    // Task<IEnumerable<Singer>> GetSingersByGenreAsync(string genre);
    // Task<IEnumerable<Singer>> GetSingersAsync(int pageNumber, int pageSize);
    // Task<IEnumerable<Singer>> GetSingersSortedAsync(string sortBy, bool ascending);
    // Task<Singer> GetSingerDetailsAsync(int singerId);
    // Task<IEnumerable<Singer>> GetSingersByPopularityAsync();
    // Task AddSingersAsync(IEnumerable<Singer> singers);
    // Task DeleteSingersAsync(IEnumerable<int> singerIds);

    // Task<int> GetSingerCountAsync();

    // Task<double> GetAverageSingerRatingAsync(int singerId);

    // Task<IEnumerable<Album>> GetSingerAlbumsAsync(int singerId);
    
    // Task<IEnumerable<Song>> GetSingerSongsAsync(int singerId);
}
