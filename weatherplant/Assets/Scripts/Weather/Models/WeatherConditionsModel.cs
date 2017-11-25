using Newtonsoft.Json;

namespace WeatherPlant.Weather.Models
{
    public class WeatherConditionsModel
    {
        [JsonProperty("id")]
        private int _id;

        [JsonProperty("main")]
        private string _main;

        [JsonProperty("description")]
        private string _description;

        [JsonProperty("icon")]
        private string _icon;

        /// <summary>
        /// Weather condition id
        /// </summary>
        /// <value>The identifier.</value>
        public int ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        /// <value>Group of weather parameters</value>
        public string Main
        {
            get { return _main; }
        }

        /// <summary>
        /// Weather condition within the group
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// Weather icon id
        /// </summary>
        /// <value>The icon.</value>
        public string Icon
        {
            get { return _icon; }
        }
    }
}
