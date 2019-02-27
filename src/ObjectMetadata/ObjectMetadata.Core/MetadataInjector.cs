using ObjectMetadata.Core.Util;

namespace ObjectMetadata.Core
{
    public class MetadataInjector: IMetadataInjector
    {
        public dynamic Inject(dynamic target)
        {
            return Metadata.Inject(target);
        }
    }
}