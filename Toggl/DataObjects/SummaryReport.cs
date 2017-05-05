using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Toggl.DataObjects
{
	public class SummaryReport : Report
	{
		[JsonProperty(PropertyName = "data")]
		public List<SummaryEntry> Data { get; set; }

		[JsonProperty(PropertyName = "total_currencies")]
		public CurrencyAmount[] TotalCurrencies { get; set; }
	}

	public class SummaryEntry
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "title")]
		public ProjectTitle Title { get; set; }

		[JsonProperty(PropertyName = "time")]
		public int Time { get; set; }

		[JsonProperty(PropertyName = "total_currencies")]
		public CurrencyAmount[] TotalCurrencies { get; set; }

		[JsonProperty(PropertyName = "items")]
		public SummaryItem[] Items { get; set; }
	}

	public class ProjectTitle
	{
		[JsonProperty(PropertyName = "project")]
		public string Project { get; set; }

		[JsonProperty(PropertyName = "client")]
		public string Client { get; set; }

		[JsonProperty(PropertyName = "color")]
		public string Color { get; set; }

		[JsonProperty(PropertyName = "hex_color")]
		public string HexColor { get; set; }
	}

	public class Title
	{
		[JsonProperty(PropertyName = "time_entry")]
		public string TimeEntry { get; set; }
	}

	public class CurrencyAmount
	{
		[JsonProperty(PropertyName = "currency")]
		public string Currency { get; set; }

		[JsonProperty(PropertyName = "amount")]
		public string Amount { get; set; }
	}

	public class SummaryItem
	{
		[JsonProperty(PropertyName = "title")]
		public Title Title { get; set; }

		[JsonProperty(PropertyName = "time")]
		public int Time { get; set; }

		[JsonProperty(PropertyName = "currency")]
		public string Currency { get; set; }

		[JsonProperty(PropertyName = "sum")]
		public string Sum { get; set; }

		[JsonProperty(PropertyName = "rate")]
		public string Rate { get; set; }

	}
}