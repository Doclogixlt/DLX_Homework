using DataAccess;
using DataAccess.Entities;
using DataAccess.Models.LogModels;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public LogRepository(LogsDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Log>> GetLogsAsync(LogFilter filter)
        {
            var query = Get();
            return GetQuery(query, filter);
        }

        public async Task<int> GetCountAsync()
        {
            return await Get().CountAsync();
        }

        public async Task AddLog(Log log)
            => await Add(log);

        private IQueryable<Log> GetQuery(IQueryable<Log> logs, LogFilter filter)
        {
            var q = logs.AsQueryable();

            if (filter != null)
            {
                q = ApplyFilter(q, filter);
            }

            return q;
        }

        private IQueryable<Log> ApplyFilter(IQueryable<Log> query, LogFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.DeviceVendor)) query = query.Where(l => l.DeviceVendor.Contains(filter.DeviceVendor));
            if (!string.IsNullOrEmpty(filter.DeviceProduct)) query = query.Where(l => l.DeviceProduct.Contains(filter.DeviceProduct));
            if (filter.DeviceVersion != null) query = query.Where(l => l.DeviceVersion == filter.DeviceVersion);
            if (!string.IsNullOrEmpty(filter.SignatureId)) query = query.Where(l => l.SignatureId.Contains(filter.SignatureId));
            if (filter.Severity != null) query = query.Where(l => l.Severity == filter.Severity);
            if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(l => l.Name.Contains(filter.Name));
            if (filter.Start != null) 
                query = query.Where(l => l.Start > DateTimeOffset.Now.AddDays(1).Date.AddDays(-1) && 
                                         l.Start < DateTimeOffset.Now.AddDays(1).Date);
            if (!string.IsNullOrEmpty(filter.Rt)) query = query.Where(l => l.Rt.Contains(filter.Rt));
            if (!string.IsNullOrEmpty(filter.Msg)) query = query.Where(l => l.Msg.Contains(filter.Msg));
            if (!string.IsNullOrEmpty(filter.Shost)) query = query.Where(l => l.Shost.Contains(filter.Shost));
            if (!string.IsNullOrEmpty(filter.Smac)) query = query.Where(l => l.Smac.Contains(filter.Smac));
            if (!string.IsNullOrEmpty(filter.Dhost)) query = query.Where(l => l.Dhost.Contains(filter.Dhost));
            if (!string.IsNullOrEmpty(filter.Dmac)) query = query.Where(l => l.Dmac.Contains(filter.Dmac));
            if (!string.IsNullOrEmpty(filter.Suser)) query = query.Where(l => l.Suser.Contains(filter.Suser));
            if (!string.IsNullOrEmpty(filter.Suid)) query = query.Where(l => l.Suid.Contains(filter.Suid));
            if (filter.ExternalId != null) query = query.Where(l => l.ExternalId == filter.ExternalId);
            if (!string.IsNullOrEmpty(filter.Cs1Label)) query = query.Where(l => l.Cs1Label.Contains(filter.Cs1Label));
            if (!string.IsNullOrEmpty(filter.Cs1)) query = query.Where(l => l.Cs1.Contains(filter.Cs1));

            return query;
        }
    }
}
