using EomWebApiProject.Models;


public interface IAlbumService {

    Task<Album> GetAlbumByIdAsync(int albumId);

    Task AddSongsToAlbumAsync (int AlbumId, List<Song> songs );


    Task AddAlbumAsync (Album album);
}