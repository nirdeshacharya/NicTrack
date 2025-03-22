using Microsoft.EntityFrameworkCore;
using NicTrackerData.Models;

namespace NicTrackerService.Services;

public class LastSmokedService : ILastSmokedService
{
    private readonly NicTracContext _context;

    public LastSmokedService(NicTracContext context)
    {
        _context = context;
    }

    public async Task<Intake?> GetLastSmokedAsync(int userId)
    {
        return await _context.Intakes
            .Include(i => i.NicotineType)
            .Include(i => i.Location)
            .Where(i => i.NicotineType.IsSmoke)
            .OrderByDescending(i => i.TimeOfIntake)
            .FirstOrDefaultAsync();
    }

    public async Task<TimeSpan> GetTimeSinceLastSmokedAsync(int userId)
    {
        var lastSmoked = await GetLastSmokedAsync(userId);
        if (lastSmoked == null)
        {
            return TimeSpan.Zero;
        }

        return DateTime.UtcNow - lastSmoked.TimeOfIntake;
    }

    public async Task<IEnumerable<Intake>> GetRecentSmokingHistoryAsync(int userId, int days)
    {
        var startDate = DateTime.UtcNow.AddDays(-days);
        return await _context.Intakes
            .Include(i => i.NicotineType)
            .Include(i => i.Location)
            .Where(i => i.NicotineType.IsSmoke && i.TimeOfIntake >= startDate)
            .OrderByDescending(i => i.TimeOfIntake)
            .ToListAsync();
    }

    public async Task<Dictionary<string, int>> GetSmokingStatisticsAsync(int userId, DateTime startDate, DateTime endDate)
    {
        var intakes = await _context.Intakes
            .Include(i => i.NicotineType)
            .Where(i => i.NicotineType.IsSmoke && i.TimeOfIntake >= startDate && i.TimeOfIntake <= endDate)
            .ToListAsync();

        var stats = new Dictionary<string, int>
        {
            { "TotalSmoked", intakes.Count },
            { "DailyAverage", intakes.Count / Math.Max(1, (endDate - startDate).Days) },
            { "MorningSmokes", intakes.Count(i => i.TimeOfIntake.Hour >= 6 && i.TimeOfIntake.Hour < 12) },
            { "AfternoonSmokes", intakes.Count(i => i.TimeOfIntake.Hour >= 12 && i.TimeOfIntake.Hour < 18) },
            { "EveningSmokes", intakes.Count(i => i.TimeOfIntake.Hour >= 18 && i.TimeOfIntake.Hour < 24) },
            { "NightSmokes", intakes.Count(i => i.TimeOfIntake.Hour >= 0 && i.TimeOfIntake.Hour < 6) }
        };

        return stats;
    }
} 