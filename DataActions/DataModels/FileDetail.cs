using System.ComponentModel.DataAnnotations;

namespace DataActions.DataModels
{
    public class FileDetail
    {
        [Key]
        public int Id { get; set; }
        public int SearchQueryId { get; set; }
        public string FilePath { get; set; }
    }
}
