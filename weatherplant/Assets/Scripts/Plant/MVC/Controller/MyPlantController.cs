using UnityEngine;
using WeatherPlant.Database;
using WeatherPlant.Plant.ViewModel;

namespace WeatherPlant.Plant.Controller
{
    public class MyPlantController : MonoBehaviour
    {
        [SerializeField]
        private PlantEntityViewModel _model;
        private DatabaseService _service;

        private void Start()
        {
            _service = new DatabaseService();
            var myPlant = _service.LoadCurrentPlant();

            _model.Model = myPlant;
        }
    }
}
