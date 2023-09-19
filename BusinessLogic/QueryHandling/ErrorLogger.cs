

using BusinessLogic.BusinessModels;

namespace BusinessLogic.QueryHandling
{
    public class ErrorLogger
    {
        private List<Error> errorLogs = new List<Error>();

        public void LogError(string errorMessage, string exceptionMessage)
        {
            errorLogs.Add(new Error(errorMessage, exceptionMessage));
        }

        public IEnumerable<Error> GetAllErrors()
        {
            foreach (var error in errorLogs)
            {
                yield return error;
            }
        }
    }
}
