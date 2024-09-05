using EomWebApiProject.Models;


public class AlbumService : IAlbumService {

    private readonly IAlbumRepository _albumRepoitory;


    public AlbumService(IAlbumRepository albumRepository) {
        _albumRepoitory = albumRepository;
    }


    public async Task AddAlbumAsync(Album album) {
        ArgumentNullException.ThrowIfNull(album);

        var albumToAdd = new Album {
            Id = album.Id,
            SingerId = album.SingerId,
            Singer = album.Singer,
            Songs = album.Songs,
            GenreId = album.GenreId,
            Genre = album.Genre,
            AlbumName = album.AlbumName,
            ReleaseDate = album.ReleaseDate,
            TrackCount = album.TrackCount,
            
        };
        await _albumRepoitory.AddAlbumAsync(albumToAdd);
    }

    public async Task<Album> GetAlbumByIdAsync(int albumId){
        return await _albumRepoitory.GetAlbumByIdAsync(albumId);

    }

    public async Task AddSongsToAlbumAsync(int albumId, List<Song> songs) {
        await _albumRepoitory.AddSongsToAlbumAsync(albumId, songs);
    }


}