using System.Runtime.CompilerServices;
using EomWebApiProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;

public class SongService : ISongService {
    
    private readonly ISongRepository _songRepository;

    public SongService(ISongRepository songRepository) {
        _songRepository = songRepository;
    }

    public async Task<IEnumerable<Song>> GetAllSongsAsync() {
        return await _songRepository.GetAllSongsAsync();
    }

    public async Task<Song> GetSongByIdAsync (int id) {
        var song = await _songRepository.GetSongByIdAsync(id) ?? throw new KeyNotFoundException("Song not found");
        return song;
    }

    public async Task<IEnumerable<Song>> GetSongByGenreAsync(int GenreId) {
        var song = await _songRepository.GetSongByGenreAsync(GenreId) ?? throw new KeyNotFoundException("Song not found");
        return song;
    }


    public async Task AddSongAsync(Song song)
    {
        ArgumentNullException.ThrowIfNull(song);

        var songToAdd = new Song
        {
            Id = song.Id,
            UserName = song.UserName,
            MusicName = song.MusicName,
            GenreId = song.GenreId,
            Genre = song.Genre,
            ReleaseDate = song.ReleaseDate,
            PublishDate = song.PublishDate,
            ImagePath = song.ImagePath,
            ImageFile = song.ImageFile,
            MusicPath = song.MusicPath,
            MusicFile = song.MusicFile,
            Lyrics = song.Lyrics,
            Review = song.Review,
            Tag = song.Tag,
            Views = song.Views,
            Slug = song.Slug,
            PlaylistSongs = song.PlaylistSongs,
            AlbumId = song.AlbumId,
            Album = song.Album,
            SongSingers = song.SongSingers,
            
        };
        await _songRepository.AddSongAsync(songToAdd);

    }

    public async Task<bool> UpdateSongAsync(Song song){
        var existingSong = await _songRepository.GetSongByIdAsync(song.Id);
        ArgumentNullException.ThrowIfNull(existingSong);

        existingSong.MusicName = song.MusicName;
        existingSong.SongSingers = song.SongSingers;
        existingSong.AlbumId = song.AlbumId;

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