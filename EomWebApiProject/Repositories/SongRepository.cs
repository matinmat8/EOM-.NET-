using EomWebApiProject.Data;
using EomWebApiProject.Models;
using Microsoft.EntityFrameworkCore;

public class SongRepository : ISongRepository {

    private readonly ApplicationDbContext _context;

    public SongRepository(ApplicationDbContext context){
        _context = context;
    }

    public async Task<IEnumerable<Song>> GetAllSongsAsync() {
        return await _context.Songs.ToListAsync();
    }

    public async Task<Song> GetSongByIdAsync(int id) {
        var entity = await _context.Songs.FindAsync(id);
        if (entity == null){
            throw new ArgumentNullException(nameof(entity), "Entity Not Found");
        }
        return entity;
    }

    public async Task<IEnumerable<Song>> GetSongByGenreAsync (int GenreId){
        var entity = await _context.Songs.Where(m => m.GenreId == GenreId).ToListAsync();
        if (entity == null) {
            throw new ArgumentNullException(nameof(entity), "Entity Not Found");
        }
        return entity;
    }


    public async Task AddSongAsync(Song song)
    {
        await _context.Songs.AddAsync(song);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateSongAsync(Song song)
    {
        var existingSong = await _context.Songs.FindAsync(song.Id);
        ArgumentNullException.ThrowIfNull(existingSong);
        _context.Songs.Update(existingSong);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteSongAsync(int id)
    {
        var song = await _context.Songs.FindAsync(id);
        if (song != null)
        {
            _context.Songs.Remove(song);
            return await _context.SaveChangesAsync() > 0;
        } return false;
    }

    public async Task<bool> DelteSongsAsync(IEnumerable<int> songIds)
    {
        var songs = await _context.Songs.Where(s => songIds.Contains(s.Id)).ToListAsync();
        if (songs == null)
        {
            _context.Songs.RemoveRange(songs);
            return await _context.SaveChangesAsync() > 0;
        } return false;
    }
};