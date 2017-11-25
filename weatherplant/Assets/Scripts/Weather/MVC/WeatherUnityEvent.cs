using System;
using UnityEngine.Events;

namespace WeatherPlant.Service
{
    [Serializable]
    public class WeatherUnityEvent : UnityEvent<Weather>
    {
    }
}
