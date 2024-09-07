using EomWebApiProject.Models;


public interface ISingerService {

    Task<IEnumerable<Singer>> GetAllSingersAsync();
  
    Task<Singer> GetSingerByIdAsync(int singerId);
  
    Task AddSingerAsync(CreateSingerDto createSingerDto);

    Task<bool> UpdateSingerAsync(UpdateSingerDto updateSingerDto);
    Task<bool> DeleteSingerAsync(int singerId);
}