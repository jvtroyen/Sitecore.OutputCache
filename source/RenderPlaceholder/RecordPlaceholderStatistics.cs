using Sitecore.Diagnostics;
using Sitecore.Diagnostics.PerformanceCounters;
using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
using System;

namespace TheReference.DotNet.Sitecore.OutputCache.RenderPlaceholder
{
    public class RecordPlaceholderStatistics : RenderPlaceholderProcessor
    {
        private string GetTraceName(string placeholderName)
        {
            return string.Format("Placeholder: {0}", placeholderName);
        }

        public override void Process(RenderPlaceholderArgs args)
        {
            try
            {
                Statistics.AddRenderingData(GetTraceName(args.PlaceholderName), (args.CustomData["timer"] as HighResTimer).Elapsed(), DataCounters.ItemsAccessed.Value - (long)args.CustomData["itemsRead"], false);
            }
            catch (Exception ex)
            {
                Log.Warn("Failed to record placeholder statistics", ex);
            }
        }
    }
}