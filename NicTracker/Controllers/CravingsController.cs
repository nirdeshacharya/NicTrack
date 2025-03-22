using Microsoft.AspNetCore.Mvc;
using NicTrackerData.Models;
using NicTrackerService.Services;

namespace NicTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CravingsController : ControllerBase
{
    private readonly ICravingsService _cravingsService;

    public CravingsController(ICravingsService cravingsService)
    {
        _cravingsService = cravingsService;
    }

    [HttpPost]
    public async Task<ActionResult<Cravings>> RecordCraving(Cravings craving)
    {
        var result = await _cravingsService.AddCravingAsync(craving);
        return CreatedAtAction(nameof(GetCraving), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cravings>> GetCraving(int id)
    {
        var craving = await _cravingsService.GetCravingAsync(id);
        if (craving == null)
        {
            return NotFound();
        }
        return craving;
    }

    [HttpGet("user/{userId}/daily")]
    public async Task<ActionResult<IEnumerable<Cravings>>> GetDailyCravings(int userId, [FromQuery] DateTime date)
    {
        var cravings = await _cravingsService.GetDailyCravingsAsync(userId, date);
        return Ok(cravings);
    }

    [HttpGet("user/{userId}/intensity")]
    public async Task<ActionResult<IEnumerable<Cravings>>> GetCravingsByIntensity(int userId, [FromQuery] int minIntensity)
    {
        var cravings = await _cravingsService.GetCravingsByIntensityAsync(userId, minIntensity);
        return Ok(cravings);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCraving(int id, Cravings craving)
    {
        if (id != craving.Id)
        {
            return BadRequest();
        }

        await _cravingsService.UpdateCravingAsync(craving);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCraving(int id)
    {
        await _cravingsService.DeleteCravingAsync(id);
        return NoContent();
    }
} 