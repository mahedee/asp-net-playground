using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : ControllerBase
    {
        private readonly IMyTransientService _transientService;
        private readonly IMyScopeService _scopedService;

        public MyController(IMyTransientService transientService, IMyScopeService scopedService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
        }


        [HttpGet("Increment")]
        public IActionResult Index()
        {
            //return Ok();
            // Increment the counter for both services
            _transientService.IncrementCounter();
            _scopedService.IncrementCounter();

            // Get the counter values for both services
            int transientCounter = _transientService.GetCounterValue();
            int scopedCounter = _scopedService.GetCounterValue();

            return Ok($"Transient Counter: {transientCounter}, Scoped Counter: {scopedCounter}");
        }

    }
}
