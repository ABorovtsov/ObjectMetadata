using System.Collections.Concurrent;

namespace ObjectMetadata.Core
{
    public class MetadataContainer : IMetadataAware
    {
        public MetadataContainer()
        {
            Metadata = new ConcurrentDictionary<string, object>();
        }

        public ConcurrentDictionary<string, object> Metadata { get; }
    }
}