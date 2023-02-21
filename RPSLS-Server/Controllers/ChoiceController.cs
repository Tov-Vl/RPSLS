using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using RpslsServer.Models;
using RpslsServer.Services.RandomNumberService;

namespace RPSLS.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ChoiceController : ControllerBase
    {
        private readonly ILogger<ChoiceController> _logger;
        private readonly IRandomNumberService _randomNumberService;

        public ChoiceController(
            ILogger<ChoiceController> logger,
            IRandomNumberService randomNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException();
            _randomNumberService = randomNumberService ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult Choices()
        {
            var gestureIds = Enum.GetValues<Gesture>();
            var gestureNames = Enum.GetNames<Gesture>().Select(x => x.ToLower());

            _logger.LogInformation("Choices requested");

            return Ok(new { id = gestureIds, name = gestureNames });
        }

        [HttpGet]
        public async Task<IActionResult> Choice()
        {
            var gesture = await _randomNumberService.GetRandomNumberAsync();

            _logger.LogInformation($"Choice requested. Result: {gesture} (Id = {gesture:d})");

            return Ok(new { id = gesture, name = gesture.GetDisplayName().ToLower() });
        }
    }
}