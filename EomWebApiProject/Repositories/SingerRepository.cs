using EomWebApiProject.Data;
using EomWebApiProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


public class SingerRepository : ISingerRepository {

    private readonly ApplicationDbContext _context;

    public SingerRepository(ApplicationDbContext context) {
        _context = context;
    }


    public async Task<IEnumerable<Singer>> GetAllSingersAsync() {
        return await _context.Singers.ToListAsync();
    }

    public async Task<Singer> GetSingerByIdAsync(int singerId) {
        var singer = await _context.Singers.FindAsync(singerId);
        ArgumentNullException.ThrowIfNull(singer);
        return singer;
    }


    public async Task<bool> UpdateSingerAsync(Singer singer) {
        _context.Singers.Update(singer);
        return await _context.SaveChangesAsync() > 0;

    }

    public async Task<bool> DeleteSingerAsync(int singerId) {
        var singer = await _context.Singers.FindAsync(singerId);
        if (singer != null) {
            _context.Singers.Remove(singer);
            return  await _context.SaveChangesAsync() > 0;
        }
        return false;
    }


    public async Task AddSingerAsync(Singer singer) {
        await _context.Singers.AddAsync(singer);
        await _context.SaveChangesAsync();
    }

}