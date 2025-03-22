using Microsoft.AspNetCore.Mvc;
using NicTrackerData.Models;
using NicTrackerService.Services;

namespace NicTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LastSmokedController : ControllerBase
{
    private readonly ILastSmokedService _lastSmokedService;
    private readonly ILogger<LastSmokedController> _logger;

    public LastSmokedController(ILastSmokedService lastSmokedService, ILogger<LastSmokedController> logger)
    {
        _lastSmokedService = lastSmokedService;
        _logger = logger;
    }

    [HttpGet("user/{userId}/last")]
    public async Task<ActionResult<Intake>> GetLastSmoked(int userId)
    {
        var lastSmoked = await _lastSmokedService.GetLastSmokedAsync(userId);
        if (lastSmoked == null)
        {
            return NotFound("No smoking history found for this user.");
        }
        return lastSmoked;
    }

    [HttpGet("user/{userId}/timeSince")]
    public async Task<ActionResult<string>> GetTimeSinceLastSmoked(int userId)
    {
        var timeSince = await _lastSmokedService.GetTimeSinceLastSmokedAsync(userId);
        if (timeSince == TimeSpan.Zero)
        {
            return NotFound("No smoking history found for this user.");
        }

        return FormatTimeSpan(timeSince);
    }

    [HttpGet("user/{userId}/history")]
    public async Task<ActionResult<IEnumerable<Intake>>> GetRecentHistory(int userId, [FromQuery] int days = 7)
    {
        var history = await _lastSmokedService.GetRecentSmokingHistoryAsync(userId, days);
        return Ok(history);
    }

    [HttpGet("user/{userId}/statistics")]
    public async Task<ActionResult<Dictionary<string, int>>> GetStatistics(
        int userId,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var start = startDate ?? DateTime.UtcNow.AddDays(-30);
        var end = endDate ?? DateTime.UtcNow;

        var stats = await _lastSmokedService.GetSmokingStatisticsAsync(userId, start, end);
        return Ok(stats);
    }

    private string FormatTimeSpan(TimeSpan timeSpan)
    {
        if (timeSpan.TotalDays >= 1)
        {
            return $"{timeSpan.Days} days, {timeSpan.Hours} hours ago";
        }
        if (timeSpan.TotalHours >= 1)
        {
            return $"{timeSpan.Hours} hours, {timeSpan.Minutes} minutes ago";
        }
        return $"{timeSpan.Minutes} minutes ago";
    }
}
