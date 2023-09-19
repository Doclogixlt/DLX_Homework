

namespace BusinessLogic.QueryHandling
{
    public static class LogEntryMapper
    {
        public static DataActions.DataModels.LogEntry ToDataModel(BusinessModels.LogEntry businessLogEntry, int searchQueryid)
        {
            return new DataActions.DataModels.LogEntry
            {
                deviceVendor = businessLogEntry.deviceVendor,
                deviceProduct = businessLogEntry.deviceProduct,
                deviceVersion = (int)businessLogEntry.deviceVersion,
                signatureId = businessLogEntry.signatureId,
                severity = businessLogEntry.severity,
                name = businessLogEntry.name,
                start = businessLogEntry.start,
                rt = businessLogEntry.rt,
                msg = businessLogEntry.msg,
                shost = businessLogEntry.shost,
                smac = businessLogEntry.smac,
                dhost = businessLogEntry.dhost,
                dmac = businessLogEntry.dmac,
                suser = businessLogEntry.suser,
                suid = businessLogEntry.suid,
                externalId = businessLogEntry.externalId,
                cs1Label = businessLogEntry.cs1Label,
                cs1 = businessLogEntry.cs1,
                SearchQueryId = searchQueryid
            };
        }
    }
}
