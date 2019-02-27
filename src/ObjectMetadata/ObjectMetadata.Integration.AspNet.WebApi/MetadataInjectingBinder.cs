using System;
using System.Collections.Concurrent;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using ObjectMetadata.Core;

namespace ObjectMetadata.Integration.AspNet.WebApi
{
    public class MetadataInjectingBinder : IModelBinder
    {
        private IMetadataInjector _metadataInjector;

        public MetadataInjectingBinder()
            : this(new MetadataInjector())
        { }

        public MetadataInjectingBinder(IMetadataInjector metadataInjector)
        {
            _metadataInjector = metadataInjector ?? throw new ArgumentNullException(nameof(metadataInjector));
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            try
            {
                string content = actionContext.ControllerContext.Request.Content
                    .ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                var value = JsonConvert.DeserializeObject(content, bindingContext.ModelType);
                bindingContext.Model = _metadataInjector.Inject(value);
                UpdateMetadata(((IMetadataAware)bindingContext.Model).Metadata, actionContext, bindingContext, content);

                return true;
            }
            catch (Exception e)
            {
                //todo: log error
                return false;
            }
        }

        public virtual void UpdateMetadata(ConcurrentDictionary<string, object> metadata,
            HttpActionContext actionContext,
            ModelBindingContext bindingContext, string content)
        {
            // For ex.: metadata.TryAdd("TestKey", "TestValue");
        }
    }
}