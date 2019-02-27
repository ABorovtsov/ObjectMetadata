using System.Collections.Concurrent;

namespace ObjectMetadata.Core
{
    public interface IMetadataAware
    {
        ConcurrentDictionary<string, object> Metadata { get; }
    }
}