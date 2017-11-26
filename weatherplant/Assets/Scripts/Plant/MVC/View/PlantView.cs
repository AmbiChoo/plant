using UnityEngine;
using WeatherPlant.Plant.Models;
using WeatherPlant.Plant.ViewModel;
using WeatherPlant.BaseMVC;

namespace WeatherPlant.Plant.View
{
    public class PlantView : BaseView<PlantModel, PlantViewModel>
    {
        private GameObject _instance;

        protected override void UpdateView(PlantModel data)
        {
            DestroyInstance();

            // Create Instance
            var loadingResource = string.Format("{0}_{1}_{2}", data.Type, data.ID, data.Stages.Count - 1);
            var prefab = Resources.Load(loadingResource) as GameObject;
            if (prefab == null)
            {
                Debug.LogErrorFormat("Could not load resource: {0}", loadingResource);
                return;
            }

            _instance = Instantiate(prefab) as GameObject;

            // Parent here
            _instance.transform.SetParent(this.transform);
            _instance.transform.localPosition = Vector3.zero;
            _instance.transform.localScale = Vector3.one;
            _instance.transform.localRotation = Quaternion.identity;
        }

        private void DestroyInstance()
        {
            if (_instance == null)
                return;

            Destroy(_instance);
            _instance = null;

            // Clear
            Resources.UnloadUnusedAssets();
        }
    }
}
