using UnityEngine;
using WeatherPlant.Weather.Models;
using WeatherPlant.Weather.ViewModel;
using WeatherPlant.Service;

namespace WeatherPlant.Weather.Controller
{
    public class WeatherController : MonoBehaviour
    {
        [SerializeField]
        private WeatherViewModel _model;
        private WeatherService _service;

        private void Awake()
        {
            CheckModel();
            CheckService();
        }

        private void Start()
        {
            _service.GetWeather(UpdateModel);
        }

        private void UpdateModel(WeatherModel data)
        {
            _model.Model = data;
        }

        private void CheckModel()
        {
            if (_model != null)
                return;

            Debug.LogWarning("Weather model is null. Searching for one");
            _model = FindObjectOfType<WeatherViewModel>();
            if (_model != null)
                return;

            Debug.LogError("No Weather model found");
        }

        private void CheckService()
        {
            // Check if exist
            _service = FindObjectOfType<WeatherService>();
            if (_service != null)
                return;

            // Add if needed
            _service = gameObject.AddComponent<WeatherService>();
        }
    }
}
