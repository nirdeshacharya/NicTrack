using NicTrackerData.Models;

namespace NicTrackerService.Services;

public interface ILastSmokedService
{
    Task<Intake?> GetLastSmokedAsync(int userId);
    Task<TimeSpan> GetTimeSinceLastSmokedAsync(int userId);
    Task<IEnumerable<Intake>> GetRecentSmokingHistoryAsync(int userId, int days);
    Task<Dictionary<string, int>> GetSmokingStatisticsAsync(int userId, DateTime startDate, DateTime endDate);
} 