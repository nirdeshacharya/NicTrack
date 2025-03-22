using Microsoft.EntityFrameworkCore;
using NicTrackerData.Models;

namespace NicTrackerService.Services;

public class IntakeService : IIntakeService
{
    private readonly NicTracContext _context;

    public IntakeService(NicTracContext context)
    {
        _context = context;
    }

    public async Task<Intake> AddIntakeAsync(Intake intake)
    {
        _context.Intakes.Add(intake);
        await _context.SaveChangesAsync();
        return intake;
    }

    public async Task<Intake?> GetIntakeAsync(int id)
    {
        return await _context.Intakes
            .Include(i => i.Location)
            .Include(i => i.NicotineType)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Intake>> GetDailyIntakeAsync(int userId, DateTime date)
    {
        return await _context.Intakes
            .Include(i => i.Location)
            .Include(i => i.NicotineType)
            .Where(i => i.TimeOfIntake.Date == date.Date)
            .OrderBy(i => i.TimeOfIntake)
            .ToListAsync();
    }

    public async Task<IEnumerable<Intake>> GetWeeklyIntakeAsync(int userId, DateTime startDate)
    {
        var endDate = startDate.AddDays(7);
        return await _context.Intakes
            .Include(i => i.Location)
            .Include(i => i.NicotineType)
            .Where(i => i.TimeOfIntake >= startDate && i.TimeOfIntake < endDate)
            .OrderBy(i => i.TimeOfIntake)
            .ToListAsync();
    }

    public async Task UpdateIntakeAsync(Intake intake)
    {
        _context.Entry(intake).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteIntakeAsync(int id)
    {
        var intake = await _context.Intakes.FindAsync(id);
        if (intake != null)
        {
            _context.Intakes.Remove(intake);
            await _context.SaveChangesAsync();
        }
    }
} 