using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json.Linq;

namespace ObjectMetadata.Integration.AspNet.WebApi
{
    public class RequestedJsonInjectingBinder: MetadataInjectingBinder
    {
        public override void UpdateMetadata(ConcurrentDictionary<string, object> metadata,
            HttpActionContext actionContext,
            ModelBindingContext bindingContext, string content)
        {
            JObject requestedJson = JObject.Parse(content);
            IEnumerable<JToken> jTokens = requestedJson.Descendants().Where(p => !p.Any());
            List<string> requestedJsonKeys = jTokens.Aggregate(new List<string>(), (properties, jToken) =>
            {
                properties.Add(jToken.Path);
                return properties;
            });

            metadata.TryAdd("RequestedJson", requestedJson);
            metadata.TryAdd("RequestedJsonKeys", requestedJsonKeys);
        }
    }
}