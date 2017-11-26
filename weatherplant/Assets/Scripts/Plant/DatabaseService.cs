using System.IO;
using System.Collections.Generic;
using WeatherPlant.Plant.Models;
using WeatherPlant.Plant.Entity;
using Newtonsoft.Json;

namespace WeatherPlant.Database
{
    public class DatabaseService
    {
        private const string PlantDatabase = "plants.json";
        private const string CurrentPlant = "myplant.json";

        public Dictionary<int, PlantModel> LoadPlants()
        {
            var rawData = File.ReadAllText(PlantDatabase);
            var data = JsonConvert.DeserializeObject<Dictionary<int, PlantModel>>(rawData);

            return data;
        }

        public PlantEntity LoadCurrentPlant()
        {
            if (!File.Exists(CurrentPlant))
            {
                UnityEngine.Debug.LogFormat("File not found {0}", CurrentPlant);
                return null;
            }

            var rawData = File.ReadAllText(CurrentPlant);
            var data = JsonConvert.DeserializeObject<PlantEntity>(rawData);

            // Assign Plant
            var plants = LoadPlants();
            data.BaseModel = plants[data.PlantID];

            return data;
        }
    }
}
