using Microsoft.EntityFrameworkCore;
using NicTrackerData.Models;

namespace NicTrackerService.Services;

public class CravingsService : ICravingsService
{
    private readonly NicTracContext _context;

    public CravingsService(NicTracContext context)
    {
        _context = context;
    }

    public async Task<Cravings> AddCravingAsync(Cravings craving)
    {
        _context.Cravings.Add(craving);
        await _context.SaveChangesAsync();
        return craving;
    }

    public async Task<Cravings?> GetCravingAsync(int id)
    {
        return await _context.Cravings
            .Include(c => c.Location)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Cravings>> GetDailyCravingsAsync(int userId, DateTime date)
    {
        return await _context.Cravings
            .Include(c => c.Location)
            .Where(c => c.TimeOfCraving.Date == date.Date)
            .OrderBy(c => c.TimeOfCraving)
            .ToListAsync();
    }

    public async Task<IEnumerable<Cravings>> GetCravingsByIntensityAsync(int userId, int minIntensity)
    {
        return await _context.Cravings
            .Include(c => c.Location)
            .Where(c => c.Intensity >= minIntensity)
            .OrderByDescending(c => c.Intensity)
            .ThenBy(c => c.TimeOfCraving)
            .ToListAsync();
    }

    public async Task UpdateCravingAsync(Cravings craving)
    {
        _context.Entry(craving).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCravingAsync(int id)
    {
        var craving = await _context.Cravings.FindAsync(id);
        if (craving != null)
        {
            _context.Cravings.Remove(craving);
            await _context.SaveChangesAsync();
        }
    }
} 