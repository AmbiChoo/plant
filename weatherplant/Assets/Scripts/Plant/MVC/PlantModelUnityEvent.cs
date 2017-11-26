using System;
using UnityEngine.Events;
using WeatherPlant.Plant.Models;

namespace WeatherPlant.Plant.Controller
{
    [Serializable]
    public class PlantModelUnityEvent : UnityEvent<PlantModel>
    {
    }
}
