﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherPlant.Plant.Models
{
    public class PlantModel
    {
        [JsonProperty("id")]
        private int _id;
        [JsonProperty("type")]
        private string _type;
        [JsonProperty("stages")]
        private List<PlantStage> _stages;

        public int ID
        {
            get { return _id; }
        }

        public string Type
        {
            get { return _type; }
        }

        public List<PlantStage> Stages
        {
            get { return _stages; }
        }
    }
}
