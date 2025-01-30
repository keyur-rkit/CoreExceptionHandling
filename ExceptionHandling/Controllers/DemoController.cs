using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("triggerError")]
        public IActionResult TriggerError()
        {
            // Simulate an unhandled exception to test exception handling.
            throw new Exception("This is a dummy exception.");
        }
    }
}
