using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;

namespace TheReference.DotNet.Sitecore.OutputCache.RenderRendering
{
    public class ApplyVaryByContext : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (args.Rendered
              || (!args.Cacheable)
              || string.IsNullOrWhiteSpace(args.CacheKey)
              || args.Rendering.RenderingItem == null)
            {
                return;
            }

            Item rendering = args.PageContext.Database.GetItem(args.Rendering.RenderingItem.ID);
            if (rendering == null || rendering["VaryByContext"] != "1")
            {
                return;
            }

            //Add id of ContextItem to cacheKey
            var itemId = args.PageContext.Item.ID.Guid.ToString();
            if (!string.IsNullOrEmpty(itemId))
            {
                args.CacheKey += "_#contextid:" + itemId;
            }
        }
    }
}