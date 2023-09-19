using BusinessLogic.BusinessModels;

namespace BusinessLogic.QueryHandling
{
    public class LogEntryComparer : IEqualityComparer<LogEntry>
    {
        public bool Equals(LogEntry x, LogEntry y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            return x.deviceVendor == y.deviceVendor
                   && x.deviceProduct == y.deviceProduct
                   && x.deviceVersion == y.deviceVersion
                   && x.signatureId == y.signatureId
                   && x.severity == y.severity
                   && x.name == y.name
                   && x.start == y.start
                   && x.rt == y.rt
                   && x.msg == y.msg
                   && x.shost == y.shost
                   && x.smac == y.smac
                   && x.dhost == y.dhost
                   && x.dmac == y.dmac
                   && x.suser == y.suser
                   && x.suid == y.suid
                   && x.externalId == y.externalId
                   && x.cs1Label == y.cs1Label
                   && x.cs1 == y.cs1;
        }

        public int GetHashCode(LogEntry obj)
        {
            if (ReferenceEquals(obj, null)) return 0;

            int hash = obj.deviceVendor?.GetHashCode() ?? 0;
            hash = (hash * 397) ^ (obj.deviceProduct?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ obj.deviceVersion.GetHashCode();
            hash = (hash * 397) ^ (obj.signatureId?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ obj.severity.GetHashCode();
            hash = (hash * 397) ^ (obj.name?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.start?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.rt?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.msg?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.shost?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.smac?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.dhost?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.dmac?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.suser?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.suid?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ obj.externalId.GetHashCode();
            hash = (hash * 397) ^ (obj.cs1Label?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (obj.cs1?.GetHashCode() ?? 0);

            return hash;
        }
    }
}
