using UnityEngine;
using WeatherPlant.Plant.Controller;
using WeatherPlant.BaseMVC;
using WeatherPlant.Plant.Entity;

namespace WeatherPlant.Plant.ViewModel
{
    public class PlantEntityViewModel : BaseViewModel<PlantEntity, PlantEntityModelUnityEvent>
    {
        [SerializeField]
        private PlantViewModel _plantModel;
        [SerializeField]
        private PlantStageViewModel _plantStage;

        private void Awake()
        {
            CheckPlantModel();
            CheckPlantStageModel();
        }

        private void CheckPlantModel()
        {
            if (_plantModel != null)
                return;

            Debug.LogWarning("Plant view model not found. Searching for one");
            _plantModel = GameObject.FindObjectOfType<PlantViewModel>();

            if (_plantModel != null)
                return;

            Debug.LogError("Plant view model not found.");
        }

        private void CheckPlantStageModel()
        {
            if (_plantStage != null)
                return;

            Debug.LogWarning("Plant Stage view model not found. Searching for one");
            _plantStage = GameObject.FindObjectOfType<PlantStageViewModel>();

            if (_plantStage != null)
                return;

            Debug.LogError("Plant view model not found.");
        }

        protected override void SetModel(PlantEntity model)
        {
            base.SetModel(model);
            _plantModel.Model = model.BaseModel;
            _plantStage.Model = model.BaseModel.Stages[model.CurrentStage];
        }
    }
}
