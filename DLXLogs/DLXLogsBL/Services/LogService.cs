using CsvHelper;
using CsvHelper.Configuration;
using DataAccess.Entities;
using DataAccess.Models.LogModels;
using DLXLogsBL.Contracts;
using Microsoft.AspNetCore.Http;
using Repository.Contracts;
using System.Globalization;

namespace DLXLogsBL.Services
{
    public class LogService : ILogService
    {
        private readonly IRepositoryManager _repository;

        public LogService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<LogListModel> GetLogs(LogFilter filter, Pagination pagination)
        {
            var logList = new LogListModel();
            var logs = await _repository.Log.GetLogsAsync(filter);

            logList.Logs = logs.Skip((pagination.Page - 1) * pagination.PerPage)
                               .Take(pagination.PerPage)
                               .Select(x => x.ToLogModel());
            logList.TotalCount = logs.Count();

            return logList;
        }

        public async Task AddLogs(IFormFile file)
        {
            try
            {

                var logs = ReadCsv(file);
                foreach (var log in logs)
                {
                    await _repository.Log.AddLog(log);
                }
                    await _repository.SaveAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<Log> ReadCsv(IFormFile file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = (args) =>
                {
                    var prepared = args.Header.ToLower();
                    return prepared;
                }
            };

            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<LogModel>().ToList();
                var logs = records.Select(l => l.ToLogEntity());
                return logs.ToList();
            }
        }
    }
}
