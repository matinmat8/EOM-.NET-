using EomWebApiProject.Models;


public interface IAlbumRepository {

    Task<Album> GetAlbumByIdAsync(int albumId);

    Task AddSongsToAlbumAsync (int AlbumId, List<Song> songs );

    // Task<IEnumerable<Song>> GetAlbumSongsAsync(int albumId);

    Task AddAlbumAsync (Album album);



    // Task<IEnumerable<Album>> GetAlbumsByGenreAsync(string genre);

    // Task<IEnumerable<Album>> SearchAlbumsAsync(string searchTerm);

    
    // Task<IEnumerable<Album>> GetSingerAlbumsAsync (int singerId);


    // Task<IEnumerable<Album>> GetAlbumsAsync(int pageNumber, int pageSize);


    // Task<IEnumerable<Album>> GetAlbumsSortedAsync(string sortBy, bool ascending);



    // Task<int> GetAlbumCountAsync();

    // Task<IEnumerable<Album>> GetAlbumsAsync ();

    // Task DeleteAlbumAsync (int Id);

    // Task UpdateAlbumAsync (Album album);



}