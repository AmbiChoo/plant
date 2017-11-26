using System;
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
            PlantEntity entity = null;
            if (!File.Exists(CurrentPlant))
            {
                entity = new PlantEntity(DateTime.Now, 1, 0);
            }
            else
            {
                var rawData = File.ReadAllText(CurrentPlant);
                entity = JsonConvert.DeserializeObject<PlantEntity>(rawData);
            }

            // Assign Plant
            var plants = LoadPlants();
            entity.BaseModel = plants[entity.PlantID];

            return entity;
        }
    }
}
