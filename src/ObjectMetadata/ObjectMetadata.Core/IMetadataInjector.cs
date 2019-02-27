namespace ObjectMetadata.Core
{
    public interface IMetadataInjector
    {
        dynamic Inject(dynamic target);
    }
}