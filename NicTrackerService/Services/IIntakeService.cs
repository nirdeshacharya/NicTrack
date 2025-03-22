using NicTrackerData.Models;

namespace NicTrackerService.Services;

public interface IIntakeService
{
    Task<Intake> AddIntakeAsync(Intake intake);
    Task<Intake?> GetIntakeAsync(int id);
    Task<IEnumerable<Intake>> GetDailyIntakeAsync(int userId, DateTime date);
    Task<IEnumerable<Intake>> GetWeeklyIntakeAsync(int userId, DateTime startDate);
    Task UpdateIntakeAsync(Intake intake);
    Task DeleteIntakeAsync(int id);
} 