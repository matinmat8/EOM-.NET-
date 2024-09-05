using EomWebApiProject.Data;
using EomWebApiProject.Models;
using Microsoft.EntityFrameworkCore;

public class GenreRepository : IGenreRepository {
    private readonly ApplicationDbContext _context;
    public GenreRepository(ApplicationDbContext context){
        _context = context;
    }

    public async Task<IEnumerable<Genre>> GetGnereAsync() {
        return await _context.Genres.ToListAsync();
    }

    public async Task AddGenreAsync(Genre genre) {
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();
    }

}