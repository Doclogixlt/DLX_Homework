

using System.ComponentModel.DataAnnotations;

namespace DataActions.DataModels
{
    public class SearchQuery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string queryString { get; set; }
        public DateTime ExecutionTime { get; set; }
        public virtual ICollection<LogEntry> LogEntries { get; set; }
        public virtual ICollection<FileDetail> FileDetails { get; set; }
    }
}
