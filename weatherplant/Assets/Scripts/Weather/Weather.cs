using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherPlant.Service
{
    public class Weather
    {
        [JsonProperty("weather")]
        private List<WeatherConditions> _conditions;
        [JsonProperty("main")]
        private WeatherMain _main;

        public List<WeatherConditions> Conditions
        {
            get { return _conditions; }
        }

        public WeatherMain Temperature
        {
            get { return _main; }
        }
    }
}
