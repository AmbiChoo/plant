using System;
using UnityEngine.Events;
using WeatherPlant.Plant.Models;

namespace WeatherPlant.Plant.Controller
{
    [Serializable]
    public class PlantStageUnityEvent : UnityEvent<PlantStageModel>
    {
    }
}
