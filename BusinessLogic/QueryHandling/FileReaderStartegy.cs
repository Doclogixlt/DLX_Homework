

using BusinessLogic.BusinessModels;
using CsvHelper;
using System.Globalization;

namespace BusinessLogic.QueryHandling
{

    public interface IFileReader
    {
        IEnumerable<LogEntry> ReadCsvFiles(IEnumerable<string> filePaths, ErrorLogger errorLogger);
    }

    public class FileReader : IFileReader
    {
        public IEnumerable<LogEntry> ReadCsvFiles(IEnumerable<string> filePaths, ErrorLogger errorLogger)
        {
            foreach (var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    errorLogger.LogError($"File not found: {filePath}", "");
                    continue;
                }

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<LogEntry>();
                        yield return record;
                    }
                }
            }
        }
    }

    public class DistinctFileReader : IFileReader
    {
        public IEnumerable<LogEntry> ReadCsvFiles(IEnumerable<string> filePaths, ErrorLogger errorLogger)
        {
            HashSet<LogEntry> uniqueLogEntries = new HashSet<LogEntry>(new LogEntryComparer());

            foreach (var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    errorLogger.LogError($"File not found: {filePath}", "");
                    continue;
                }

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<LogEntry>();
                        if (uniqueLogEntries.Add(record))
                        {
                            yield return record;
                        }
                    }
                }
            }
        }
    }
}
