using NicTrackerData.Models;

namespace NicTrackerService.Services;

public interface ICravingsService
{
    Task<Cravings> AddCravingAsync(Cravings craving);
    Task<Cravings?> GetCravingAsync(int id);
    Task<IEnumerable<Cravings>> GetDailyCravingsAsync(int userId, DateTime date);
    Task<IEnumerable<Cravings>> GetCravingsByIntensityAsync(int userId, int minIntensity);
    Task UpdateCravingAsync(Cravings craving);
    Task DeleteCravingAsync(int id);
} 