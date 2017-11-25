using System;
using UnityEngine.Events;
using WeatherPlant.Weather.Models;

namespace WeatherPlant.Weather.Controller
{
    [Serializable]
    public class WeatherUnityEvent : UnityEvent<WeatherModel>
    {
    }
}
