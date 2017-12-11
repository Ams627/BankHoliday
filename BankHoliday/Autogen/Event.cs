using System;
using Newtonsoft.Json;

namespace BankHoliday
{
    public partial class Event
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
