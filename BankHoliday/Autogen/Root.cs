using Newtonsoft.Json;

namespace BankHoliday
{
    public partial class Root
    {
        [JsonProperty("england-and-wales")]
        public Events EnglandAndWales { get; set; }

        [JsonProperty("scotland")]
        public Events Scotland { get; set; }
        public static Root FromJson(string json) => JsonConvert.DeserializeObject<Root>(json, Converter.Settings);
    }
}
