

namespace BusinessLogic.BusinessModels
{
    public class LogEntry
    {
        public string deviceVendor { get; set; }
        public string deviceProduct { get; set; }
        public double deviceVersion { get; set; }
        public string signatureId { get; set; }
        public int severity { get; set; }
        public string name { get; set; }
        public string start { get; set; }
        public string rt { get; set; }
        public string msg { get; set; }
        public string shost { get; set; }
        public string smac { get; set; }
        public string dhost { get; set; }
        public string dmac { get; set; }
        public string suser { get; set; }
        public string suid { get; set; }
        public int externalId { get; set; }
        public string cs1Label { get; set; }
        public string cs1 { get; set; }

        public object GetPropertyValue(string propertyName)
        {
            var propertyInfo = this.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException("No property with the name '" + propertyName+"'");
            }
            return propertyInfo.GetValue(this, null);
        }
    }
}
