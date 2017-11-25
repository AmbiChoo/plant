using System;
using UnityEngine;

namespace WeatherPlant.Service
{
    public class WeatherModel : MonoBehaviour
    {
        [SerializeField]
        private WeatherUnityEvent _onModelUpdate;
        private Weather _currentModel;

        public event Action<Weather> OnModelUpdate;

        /// <summary>
        /// Gets or sets the current Weather model
        /// </summary>
        /// <value>The model.</value>
        public Weather Model
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
