using Microsoft.AspNetCore.Mvc;

namespace NicTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class LastSmokedController : ControllerBase
{
   

    private readonly ILogger<LastSmokedController> _logger;

    public LastSmokedController(ILogger<LastSmokedController> logger)
    {
        _logger = logger;
    }

   
}
