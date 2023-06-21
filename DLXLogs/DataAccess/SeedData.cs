using CsvHelper;
using CsvHelper.Configuration;
using DataAccess.Entities;
using DataAccess.Models.LogModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            int logId = 1;
            var dbContextAssembly = typeof(LogsDbContext).Assembly;
            var assemblyPath = dbContextAssembly.Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            var csvFile = Path.Combine(assemblyDirectory, "Data", "logData.csv");

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = (args) =>
                {
                    var prepared = args.Header.ToLower();
                    return prepared;
                }
            };

            using (var reader = new StreamReader(csvFile))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<LogModel>().ToList();
                var logs = records.Select(l => l.ToLogEntity());

                foreach (var log in logs)
                {
                    log.Id = logId;
                    modelBuilder.Entity<Log>().HasData(log);
                    logId++;
                }
            }
        }
    }
}
