using Newtonsoft.Json;

namespace BankHoliday
{
    public partial class Events
    {
        [JsonProperty("events")]
        public Event[] BankHolidays { get; set; }
    }
}
