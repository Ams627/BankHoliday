using Newtonsoft.Json;

namespace BankHoliday
{
    public static class Serialize
    {
        public static string ToJson(this Root self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
