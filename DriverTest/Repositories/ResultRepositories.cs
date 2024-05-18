using DriverTest.Models;
using Microsoft.EntityFrameworkCore;
using Results = Microsoft.AspNetCore.Http.Results;

namespace DriverTest.Repositories;

class ResultRepositories : IResultRepositories
{
    private readonly DriverTestContext _context;
    private readonly ILogger _logger;
    
    public ResultRepositories(DriverTestContext context, ILogger<ResultRepositories> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<DriverTest.Models.Results>> GetAllResults()
    {
        var result = await _context.Results.Take(15).ToListAsync();
        _logger.LogTrace("GetAllResults {Count}",  result.Count);
        return result;
    }

    public async Task Save()
    {
       var ret = await _context.SaveChangesAsync();
       _logger.LogInformation("Record changed {Count}", ret);
    }

    public async Task Add(Models.Results results)
    {
        await _context.Results.AddAsync(results);
    }

    public bool CheckResultsExist(Guid resultsId)
    {
        return _context.Results.Any(x => x.Id == resultsId);
    }


    async Task<bool> CheckResultsExistAsync(Guid resultsId)
        {
            return await _context.Results.AnyAsync(x => x.Id == resultsId);
        }
    
}