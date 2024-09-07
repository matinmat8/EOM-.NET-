using EomWebApiProject.Models;



public class SingerService : ISingerService {

    private readonly ISingerRepository _singerRepository;


    public SingerService(ISingerRepository singerRepository) {
        _singerRepository = singerRepository;
    }


    public async Task<IEnumerable<Singer>> GetAllSingersAsync() {
        return await _singerRepository.GetAllSingersAsync();
    }


    public async Task<Singer> GetSingerByIdAsync(int singerId) {
        return await _singerRepository.GetSingerByIdAsync(singerId);
    }

    
    public async Task AddSingerAsync(CreateSingerDto createSingerDto) {
        var singer = new Singer {
            Id = createSingerDto.Id,
            Name = createSingerDto.Name,
            GenreId = createSingerDto.GenreId,
            AlbumId = createSingerDto.AlbumId,
            Birth = createSingerDto.Birth,
            Death = createSingerDto.Death,
            AboutSinger = createSingerDto.AboutSinger
        };

        await _singerRepository.AddSingerAsync(singer);

    }


    public async Task<bool> UpdateSingerAsync (UpdateSingerDto updateSingerDto) {
        var singerToUpdate = await _singerRepository.GetSingerByIdAsync(updateSingerDto.Id);
        ArgumentNullException.ThrowIfNull(singerToUpdate);

        singerToUpdate.Name = updateSingerDto.Name;
        singerToUpdate.GenreId = updateSingerDto.GenreId;
        singerToUpdate.AlbumId = updateSingerDto.AlbumId;
        singerToUpdate.Birth = updateSingerDto.Birth;
        singerToUpdate.Death = updateSingerDto.Death;
        singerToUpdate.AboutSinger = updateSingerDto.AboutSinger;
        
        return await _singerRepository.UpdateSingerAsync(singerToUpdate);
    }


    public async Task<bool> DeleteSingerAsync(int singerId) {
        return await _singerRepository.DeleteSingerAsync(singerId);
    }
}