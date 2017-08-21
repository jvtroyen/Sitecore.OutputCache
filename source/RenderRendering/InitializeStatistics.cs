using Sitecore.Diagnostics;
using Sitecore.Diagnostics.PerformanceCounters;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;

namespace TheReference.DotNet.Sitecore.OutputCache.RenderRendering
{
    public class InitializeStatistics : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            args.CustomData.Add("timer", new HighResTimer(true));
            args.CustomData.Add("itemsRead", DataCounters.ItemsAccessed.Value);
        }
    }
}