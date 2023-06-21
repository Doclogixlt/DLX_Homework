using DataAccess.Entities;

namespace DataAccess.Models.LogModels
{
    public class LogModel
    {
        public string DeviceVendor { get; set; }
        public string DeviceProduct { get; set; }
        public double DeviceVersion { get; set; }
        public string SignatureId { get; set; }
        public int Severity { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Start { get; set; }
        public string Rt { get; set; }
        public string Msg { get; set; }
        public string Shost { get; set; }
        public string Smac { get; set; }
        public string Dhost { get; set; }
        public string Dmac { get; set; }
        public string Suser { get; set; }
        public string Suid { get; set; }
        public int ExternalId { get; set; }
        public string Cs1Label { get; set; }
        public string Cs1 { get; set; }

        public Log ToLogEntity()
        {
            return new Log
            {
                DeviceVendor = DeviceVendor,
                DeviceProduct = DeviceProduct,
                DeviceVersion = DeviceVersion,
                SignatureId = SignatureId,
                Severity = Severity,
                Name = Name,
                Start = Start.HasValue ? Start.Value : DateTime.Now,
                Rt = Rt,
                Msg = Msg,
                Shost = Shost,
                Smac = Smac,
                Dhost = Dhost,
                Dmac = Dmac,
                Suser = Suser,
                Suid = Suid,
                ExternalId = ExternalId,
                Cs1Label = Cs1Label,
                Cs1 = Cs1
            };
        }
    }
}
