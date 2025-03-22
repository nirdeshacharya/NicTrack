using Microsoft.AspNetCore.Mvc;
using NicTrackerData.Models;
using NicTrackerService.Services;

namespace NicTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IntakeController : ControllerBase
{
    private readonly IIntakeService _intakeService;

    public IntakeController(IIntakeService intakeService)
    {
        _intakeService = intakeService;
    }

    [HttpPost]
    public async Task<ActionResult<Intake>> RecordIntake(Intake intake)
    {
        var result = await _intakeService.AddIntakeAsync(intake);
        return CreatedAtAction(nameof(GetIntake), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Intake>> GetIntake(int id)
    {
        var intake = await _intakeService.GetIntakeAsync(id);
        if (intake == null)
        {
            return NotFound();
        }
        return intake;
    }

    [HttpGet("user/{userId}/daily")]
    public async Task<ActionResult<IEnumerable<Intake>>> GetDailyIntake(int userId, [FromQuery] DateTime date)
    {
        var intakes = await _intakeService.GetDailyIntakeAsync(userId, date);
        return Ok(intakes);
    }

    [HttpGet("user/{userId}/weekly")]
    public async Task<ActionResult<IEnumerable<Intake>>> GetWeeklyIntake(int userId, [FromQuery] DateTime startDate)
    {
        var intakes = await _intakeService.GetWeeklyIntakeAsync(userId, startDate);
        return Ok(intakes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIntake(int id, Intake intake)
    {
        if (id != intake.Id)
        {
            return BadRequest();
        }

        await _intakeService.UpdateIntakeAsync(intake);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIntake(int id)
    {
        await _intakeService.DeleteIntakeAsync(id);
        return NoContent();
    }
} 