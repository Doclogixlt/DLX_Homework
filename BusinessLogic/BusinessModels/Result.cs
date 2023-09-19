using System.Text.Encodings.Web;
using System.Text.Json;

namespace BusinessLogic.BusinessModels
{
    public class Result
    {
        public string SearchQuery { get; set; }
        public int Count { get; set; }
        public int HighestSeverity { get; set; }
        public List<LogEntry> LogEntries { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }
    }
}
