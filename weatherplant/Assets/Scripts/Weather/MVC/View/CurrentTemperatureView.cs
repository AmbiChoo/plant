using UnityEngine;
using UnityEngine.UI;

namespace WeatherPlant.Service
{
    public class CurrentTemperatureView : MonoBehaviour
    {
        [SerializeField]
        private WeatherModel _model;
        [SerializeField]
        private TemperatureUnitType _units;
        [SerializeField]
        private Text _text;

        private void OnEnable()
        {
            _model.OnModelUpdate += UpdateView;
        }

        private void OnDisable()
        {
            _model.OnModelUpdate -= UpdateView;
        }

        private void UpdateView(Weather data)
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
