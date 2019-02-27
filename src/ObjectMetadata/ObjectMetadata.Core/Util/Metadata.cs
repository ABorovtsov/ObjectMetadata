using AutoMapper;
using Castle.DynamicProxy;

namespace ObjectMetadata.Core.Util
{
    public class Metadata
    {
        public static dynamic Inject(dynamic target)
        {
            dynamic classProxy = new ProxyGenerator().CreateClassProxy(target.GetType(), null, CreateOptions(), null);
            Mapper.Map(target, classProxy);

            return classProxy;
        }

        private static ProxyGenerationOptions CreateOptions()
        {
            var generationOptions = new ProxyGenerationOptions();
            generationOptions.AddMixinInstance(new MetadataContainer());

            return generationOptions;
        }
    }
}