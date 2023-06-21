using DataAccess.Entities;
using DataAccess.Models.LogModels;
using Microsoft.AspNetCore.Http;

namespace DLXLogsBL.Contracts
{
    public interface ILogService
    {
        Task AddLogs(IFormFile file);
        Task<LogListModel> GetLogs(LogFilter filter, Pagination pagination);
    }
}
