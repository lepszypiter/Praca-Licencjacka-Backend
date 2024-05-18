namespace DriverTest.Repositories;

public interface IResultRepositories
{
    Task<IReadOnlyCollection<DriverTest.Models.Results>> GetAllResults();
    Task Save();
    Task Add(DriverTest.Models.Results results);
    bool CheckResultsExist(Guid resultsId);
}