using EomWebApiProject.Data;
using EomWebApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;


public class AlbumRepository : IAlbumRepository {

    private readonly ApplicationDbContext _context;

    public AlbumRepository(ApplicationDbContext context) {
        _context = context;
    }


    public async Task AddAlbumAsync( Album album ) {
        await _context.Albums.AddAsync(album);
        await _context.SaveChangesAsync();
    }

    public async Task<Album> GetAlbumByIdAsync(int albumId) {
        // var album = await _context.Albums.Include(a => a.Songs).FirstOrDefaultAsync(a => a.Id == albumId);
        var album = await _context.Albums.FindAsync(albumId);
        if (album == null) {
            throw new ArgumentNullException(nameof(album), "Entity Not Found");

        }
        return album;
    }

    public async Task AddSongsToAlbumAsync(int albumId, List<Song> songs) {
        var album = await GetAlbumByIdAsync(albumId);
        if (album != null) {
            album.Songs.AddRange(songs);
            await _context.SaveChangesAsync();
        }
        throw new ArgumentNullException(nameof(album), "Album Not Found");
    }
}