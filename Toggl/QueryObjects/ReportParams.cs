using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Toggl.DataObjects;

namespace Toggl.QueryObjects
{
    public class ReportParams : BaseDataObject
    {
        [JsonProperty(PropertyName = "user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty(PropertyName = "workspace_id")]
        public int WorkspaceId { get; set; }

        [JsonProperty(PropertyName = "since")]
        public string Since { get; set; }

        [JsonProperty(PropertyName = "until")]
        public string Until { get; set; }

        [JsonProperty(PropertyName = "billable")]
        public string Billable { get; set; }

        [JsonProperty(PropertyName = "client_ids")]
        public List<int> ClientIds { get; set; }

        [JsonProperty(PropertyName = "project_ids")]
        public List<int> ProjectIds { get; set; }

        [JsonProperty(PropertyName = "user_ids")]
        public List<int> UserIds { get; set; }

		[JsonProperty(PropertyName = "members_of_group_ids")]
		public List<int> MembersOfGroupIds { get; set; }

		[JsonProperty(PropertyName = "or_members_of_group_ids")]
		public List<int> OrMembersOfGroupIds { get; set; }

        [JsonProperty(PropertyName = "tag_ids")]
        public List<int> TagIds { get; set; }

        [JsonProperty(PropertyName = "task_ids")]
        public string TaskIds { get; set; }

        [JsonProperty(PropertyName = "time_entry_ids")]
        public List<int> TimeEntryIds { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "without_description")]
        public bool? WithoutDescription { get; set; }

		[JsonProperty(PropertyName = "order_field")]
		public string OrderField { get; set; }
		//For detailed reports: "date", "description", "duration", or "user"
		//For summary reports: "title", "duration", or "amount"
		//For weekly reports: "title", "day1", "day2", "day3", "day4", "day5", "day6", "day7", or "week_total"

        [JsonProperty(PropertyName = "order_desc")]
	    public string OrderDesc { get; set; }
		//"on" for descending, or "off" for ascending order.

        [JsonProperty(PropertyName = "distinct_rates")]
		public string DistinctRates { get; set; }
		//: "on" or "off". Defaults to "off".

		[JsonProperty(PropertyName = "rounding")]
		public string Rounding { get; set; }
		//rounding: "on" or "off". Defaults to "off". Rounds time according to workspace settings.

		[JsonProperty(PropertyName = "display_hours")]
        public string DisplayHours { get; set; }

	}
}
