using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Diagnostics.PerformanceCounters;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;
using System;

namespace TheReference.DotNet.Sitecore.OutputCache.RenderRendering
{
    public class RecordStatistics : RenderRenderingProcessor
    {
        private string GetTraceName(Rendering rendering)
        {
            return string.Format("{0} ({1})", rendering.RenderingItem.DisplayName, rendering.RenderingItem.InnerItem.Paths.Path);
        }

        public override void Process(RenderRenderingArgs args)
        {
            try
            {
                if (!(args.Rendering.RenderingItem.InnerItem.TemplateID != ID.Parse("{B6F7EEB4-E8D7-476F-8936-5ACE6A76F20B}")))
                    return;
                Statistics.AddRenderingData(GetTraceName(args.Rendering), (args.CustomData["timer"] as HighResTimer).Elapsed(), DataCounters.ItemsAccessed.Value - (long)args.CustomData["itemsRead"], args.UsedCache);
            }
            catch (Exception ex)
            {
                Log.Warn("Failed to record rendering statistics", ex);
            }
        }
    }
}