using Newtonsoft.Json;

namespace WeatherPlant.Weather.Models
{
    public class WeatherMainModel
    {
        [JsonProperty("temp")]
        private float _temp;
        [JsonProperty("pressure")]
        private float _pressure;
        [JsonProperty("humidity")]
        private float _humidity;
        [JsonProperty("temp_min")]
        private float _tempMin;
        [JsonProperty("temp_max")]
        private float _tempMax;
        [JsonProperty("sea_level")]
        private float _seaLevel;
        [JsonProperty("grnd_level")]
        private float _grndLevel;

        /// <summary>
        /// Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        /// <value>The temperature.</value>
        public float Temperature
        {
            get { return _temp; }
        }

        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        /// </summary>
        /// <value>The pressure.</value>
        public float Pressure
        {
            get { return _pressure; }
        }

        /// <summary>
        /// Humidity, %
        /// </summary>
        /// <value>The humidity.</value>
        public float Humidity
        {
            get { return _humidity; }
        }

        /// <summary>
        /// Minimum temperature at the moment.
        /// This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally).
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        /// <value>The temperature minimum.</value>
        public float TemperatureMinimum
        {
            get { return _tempMin; }
        }

        /// <summary>
        /// Maximum temperature at the moment.
        /// This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally).
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        /// <value>The temperature max.</value>
        public float TemperatureMax
        {
            get { return _tempMax; }
        }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa
        /// </summary>
        /// <value>The sea level.</value>
        public float AtmosphericPressureSeaLevel
        {
            get { return _seaLevel; }
        }

        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        /// <value>The atmospheric pressure ground level.</value>
        public float AtmosphericPressureGroundLevel
        {
            get { return _grndLevel; }
        }
    }
}
