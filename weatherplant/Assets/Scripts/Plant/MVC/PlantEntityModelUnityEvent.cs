using System;
using UnityEngine.Events;
using WeatherPlant.Plant.Entity;

namespace WeatherPlant.Plant.Controller
{
    [Serializable]
    public class PlantEntityModelUnityEvent : UnityEvent<PlantEntity>
    {
    }
}
