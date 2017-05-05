using Newtonsoft.Json;

namespace Toggl.QueryObjects
{
	public class SummaryReportParams : ReportParams
	{
		[JsonProperty(PropertyName = "grouping")]
		public string Grouping { get; set; }

		[JsonProperty(PropertyName = "subgrouping")]
		public string Subgrouping { get; set; }

		[JsonProperty(PropertyName = "subgrouping_ids")]
		public bool SubgroupingIds { get; set; }

		[JsonProperty(PropertyName = "grouped_time_entry_ids")]
		public bool GroupedTimeEntryIds { get; set; }
	}
}