using System;
using UnityEngine;
using WeatherPlant.Weather.Models;
using WeatherPlant.Weather.Controller;

namespace WeatherPlant.Weather.ViewModel
{
    public class WeatherViewModel : MonoBehaviour
    {
        [SerializeField]
        private WeatherUnityEvent _onModelUpdate;
        private WeatherModel _currentModel;

        public event Action<WeatherModel> OnModelUpdate;

        /// <summary>
        /// Gets or sets the current Weather model
        /// </summary>
        /// <value>The model.</value>
        public WeatherModel Model
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                TriggerModelUpdate();
            }
        }

        private void TriggerModelUpdate()
        {
            if (OnModelUpdate != null)
                OnModelUpdate.Invoke(_currentModel);
            if (_onModelUpdate != null)
                _onModelUpdate.Invoke(_currentModel);
        }
    }
}
