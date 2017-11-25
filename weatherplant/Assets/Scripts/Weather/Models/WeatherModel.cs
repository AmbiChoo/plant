using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherPlant.Weather.Models
{
    public class WeatherModel
    {
        [JsonProperty("weather")]
        private List<WeatherConditionsModel> _conditions;
        [JsonProperty("main")]
        private WeatherMainModel _main;

        public List<WeatherConditionsModel> Conditions
        {
            get { return _conditions; }
        }

        public WeatherMainModel Temperature
        {
            get { return _main; }
        }
    }
}
