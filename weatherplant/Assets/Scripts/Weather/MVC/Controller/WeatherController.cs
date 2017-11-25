using UnityEngine;

namespace WeatherPlant.Service
{
    public class WeatherController : MonoBehaviour
    {
        [SerializeField]
        private WeatherModel _model;
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

        private void UpdateModel(Weather data)
        {
            _model.Model = data;
        }

        private void CheckModel()
        {
            if (_model != null)
                return;

            Debug.LogWarning("Weather model is null. Searching for one");
            _model = FindObjectOfType<WeatherModel>();
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
