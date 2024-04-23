using DriverTest.Repositories;

namespace DriverTest;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ResultsController : ControllerBase
{
   
        private readonly IResultRepositories _resultRepositories;
        private readonly ILogger _logger;
        
        public ResultsController(IResultRepositories resultRepositories, ILogger<ResultsController> logger)
        {
            _resultRepositories = resultRepositories;
            _logger = logger;
        }
    // GET: api/ResultsController
    //[HttpGet]
    public async Task<ActionResult<IEnumerable<DriverTest.Models.Results>>> GetResults()
        {
            _logger.LogInformation("GET: GetAllResults");
            var results = await _resultRepositories.GetAllResults();
            return Ok(results);
        }
    // POST: api/ResultsController
    [HttpPost]
    public async Task<ActionResult<DriverTest.Models.Results>> PostResults([FromForm]DriverTest.Models.Results results)
    {
        _logger.LogInformation("POST: AddResults {Name} {Age} {Score}", results.Name, results.Age, results.Score);
        await _resultRepositories.Add(results);
        await _resultRepositories.Save();
        return CreatedAtAction("GetResults", new { id = results.Id }, results);
    }
    
}