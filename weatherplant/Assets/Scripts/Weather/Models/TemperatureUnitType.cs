
namespace WeatherPlant.Weather.Models
{
    public enum TemperatureUnitType
    {
        /// <summary>
        /// Kelvin degrees
        /// </summary>
        Kelvin,

        /// <summary>
        /// Celcius = Kelvin - 273.15
        /// </summary>
        Celcius,

        /// <summary>
        /// Fahrenheit = Kelvin * 9/5 - 459.67
        /// </summary>
        Fahrenheit
    }
}
