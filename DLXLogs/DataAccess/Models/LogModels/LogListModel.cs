namespace DataAccess.Models.LogModels
{
    public class LogListModel
    {
        public int TotalCount { get; set; }
        public IEnumerable<LogModel> Logs { get; set; }
    }
}
