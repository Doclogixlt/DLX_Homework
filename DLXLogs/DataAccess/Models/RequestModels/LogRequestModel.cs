using DataAccess.Models.LogModels;

namespace DataAccess.Models.RequestModels
{
    public class LogRequestModel
    {
        public LogFilter LogFilter { get; set; }
        public Pagination Pagination { get; set; }
    }
}
