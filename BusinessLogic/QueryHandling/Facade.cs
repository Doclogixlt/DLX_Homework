using BusinessLogic.BusinessModels;
using DataActions;
using DataActions.DataModels;
using DataActions.Repositories;

namespace BusinessLogic.QueryHandling
{
    public class Facade
    {
        private class Settings
        {
            public bool SaveToDb { get; set;}
            public bool AllowDuplicates { get; set; }
        }

        private Settings _settings;
        private Tokenizer _tokenizer;
        private QueryParser _queryParser;
        private ErrorLogger _errorLogger;
        private IFileReader _fileReader;
        private Result _results;

        private readonly LogEntryRepository _logEntryRepository;
        private readonly SearchQueryRepository _searchQueryRepository;
        private readonly FileDetailRepository _fileDetailRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public Facade(LogEntryRepository logEntryRepository, SearchQueryRepository searchQueryRepository, FileDetailRepository fileDetailRepository, ApplicationDbContext applicationDbContext)
        {
            _settings = new Settings();
            _tokenizer = new Tokenizer();
            _searchQueryRepository = searchQueryRepository;
            _fileDetailRepository = fileDetailRepository;
            _logEntryRepository = logEntryRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> ExecuteQuery(string query, List<string> filePaths)
        {
            _results = new Result();
            _results.LogEntries = new List<BusinessModels.LogEntry>();
            _errorLogger = new ErrorLogger();
            _results.SearchQuery = query;

            //Tokenizing input query
            var tokens = new List<Token>();
            try
            {
                tokens = _tokenizer.Tokenize(query);
            }
            catch (Exception ex)
            {
                _errorLogger.LogError("Not supported symbols or syntax.", ex.Message);
                return false;
            }

            //building abstract syntax tree
            ExpressionNode ast = null;
            _queryParser = new QueryParser(tokens);
            try
            {
                ast = _queryParser.Parse();
            }
            catch (Exception ex)
            {
                _errorLogger.LogError("Incorrect order of comparison or logical operators.", ex.Message);
                return false;
            }

            //Evaluating file rows
            _fileReader = _settings.AllowDuplicates ? new FileReader() : new DistinctFileReader();
            try
            {
                int highestSeverity = 0;
                foreach(BusinessModels.LogEntry entry in _fileReader.ReadCsvFiles(filePaths, _errorLogger))
                {
                    if (Evaluator.Evaluate(ast, entry))
                    {
                        _results.LogEntries.Add(entry);
                        if (entry.severity > highestSeverity)
                        {
                            highestSeverity = entry.severity;
                        }
                    }
                }
                _results.Count = _results.LogEntries.Count;
                _results.HighestSeverity = highestSeverity;
            }
            catch (Exception ex)
            {
                _errorLogger.LogError("Error occured while evaluating data rows", ex.Message);
                return false;
            }

            //Optional: Saving to database
            if (_settings.SaveToDb)
            {
                try
                {
                    await SaveResultsToDatabase(query, filePaths);
                }
                catch (Exception ex)
                {
                    _errorLogger.LogError("Error occured while saving query results to database.", ex.Message);
                }
            }

            return true;
        }

        private async Task SaveResultsToDatabase(string query, List<string> filePaths)
        {
            using var transaction = _applicationDbContext.Database.BeginTransaction();
            try
            {
                var searchQuery = new SearchQuery()
                {
                    queryString = query,
                    ExecutionTime = DateTime.Now
                };

                await _searchQueryRepository.SaveSearchQueryAsync(searchQuery);

                int searchQueryId = searchQuery.Id;

                var fileDetails = new List<FileDetail>();
                foreach (string filePath in filePaths)
                {
                    fileDetails.Add(new FileDetail()
                    {
                        SearchQueryId = searchQueryId,
                        FilePath = filePath
                    });
                }

                await _fileDetailRepository.SaveBatchAsync(fileDetails);

                var logEntries = new List<DataActions.DataModels.LogEntry>();
                foreach (var logEntry in _results.LogEntries)
                {
                    logEntries.Add(LogEntryMapper.ToDataModel(logEntry, searchQueryId));
                }

                if (logEntries.Count > 0)
                {
                    await _logEntryRepository.SaveBatchAsync(logEntries);
                }


                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
        }

        public string GetResultsJson()
        {
            return _results.ToString();
        }

        public void InitializeSettings(bool saveToDb, bool allowDuplicates)
        {
            _settings.SaveToDb = saveToDb;
            _settings.AllowDuplicates = allowDuplicates;
        }

        public int HighestSeverity()
        {
            return _results.HighestSeverity;
        }

        public IEnumerable<Error> GetErrors()
        {
            foreach (var error in _errorLogger.GetAllErrors())
            {
                yield return error;
            }
        }
    }
}
