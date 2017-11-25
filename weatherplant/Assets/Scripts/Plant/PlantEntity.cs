using System;
using Newtonsoft.Json;
using WeatherPlant.Plant.Models;

namespace WeatherPlant.Plant.Entity
{
    public class PlantEntity
    {
        [JsonProperty("plant_date")]
        private DateTime _plantDate;
        [JsonProperty("plant_id")]
        private int _plantID;
        private PlantModel _baseModel;

        public DateTime PlantDate
        {
            get { return _plantDate; }
        }

        public int PlantID
        {
            get { return _plantID; }
        }

        public PlantModel BaseModel
        {
            get { return _baseModel; }
            set
            {
                if (value.ID != _plantID)
                {
                    UnityEngine.Debug.LogError("Wrong ID");
                    return;
                }
                _baseModel = value;
            }
        }
    }
}