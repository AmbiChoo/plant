using UnityEngine;
using UnityEngine.UI;
using WeatherPlant.Weather.Models;
using WeatherPlant.Weather.ViewModel;
using WeatherPlant.BaseMVC;

namespace WeatherPlant.Weather.View
{
    public class CurrentTemperatureView : BaseView<WeatherModel, WeatherViewModel>
    {
        [SerializeField]
        private TemperatureUnitType _units;
        [SerializeField]
        private Text _text;

        protected override void UpdateView(WeatherModel data)
        {
            UpdateView(data.Temperature.Temperature);
        }

        private void UpdateView(float kelvinDegrees)
        {
            float degrees = 0;
            string suffix = "";
            switch (_units)
            {
                case TemperatureUnitType.Kelvin:
                    degrees = kelvinDegrees;
                    suffix = "K";
                    break;
                case TemperatureUnitType.Celcius:
                    degrees = kelvinDegrees - 273.15f;
                    suffix = "C";
                    break;
                case TemperatureUnitType.Fahrenheit:
                    degrees = kelvinDegrees * (9 / 5) - 459.67f;
                    suffix = "F";
                    break;

            }
            _text.text = string.Format("{0:0.00} °{1}", degrees, suffix);
        }
    }
}
