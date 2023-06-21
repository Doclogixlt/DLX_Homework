using DataAccess.Entities;
using DataAccess.Models.LogModels;

namespace Repository.Contracts
{
    public interface ILogRepository
    {
        Task<IQueryable<Log>> GetLogsAsync(LogFilter filter);
        Task AddLog(Log log);
        Task<int> GetCountAsync();
    }
}
