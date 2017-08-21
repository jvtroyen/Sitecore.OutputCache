using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;

namespace TheReference.DotNet.Sitecore.OutputCache.RenderRendering
{
    public class ApplyClearOnIndexUpdate : RenderRenderingProcessor
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
            if (rendering == null || rendering["ClearOnIndexUpdate"] != "1")
            {
                return;
            }

            //Add _#index. MVC renderings do not get these from Sitecore OOTB
            if (!args.CacheKey.Contains("_#index"))
            {
                args.CacheKey += "_#index";
            }
        }
    }
}