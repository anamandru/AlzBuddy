using Newtonsoft.Json;

namespace AlzBuddy.Receivers
{
    public class DataIncoming
    {
        [JsonProperty("temperature")]
        public double temperature;

        [JsonProperty("coPpm")]
        public double coPpm;

        [JsonProperty("waterLevel")]
        public int waterLevel;

        [JsonProperty("secondsFridge")]
        public int secondsFridge;

       
    }
}
