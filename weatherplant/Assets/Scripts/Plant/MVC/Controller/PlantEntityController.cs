using System;
using System.Collections;
using UnityEngine;
using WeatherPlant.Plant.ViewModel;

namespace WeatherPlant.Plant.Controller
{
    public class PlantEntityController : MonoBehaviour
    {
        [SerializeField]
        private PlantEntityViewModel _model;
        private Coroutine _coroutine;

        private void OnEnable()
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(CheckForStage());
            }
        }

        private void OnDisable()
        {
            if (_coroutine == null)
                return;
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator CheckForStage()
        {
            while (true)
            {
                UpdateStage();
                yield return new WaitForSeconds(1);
            }
        }

        public void UpdateStage()
        {
            var model = _model.Model;
            if (model == null)
                return;

            var now = DateTime.Now;
            DateTime accumulatedTime = model.PlantDate;
            for (int i = 0; i < model.BaseModel.Stages.Count; ++i)
            {
                accumulatedTime += model.BaseModel.Stages[i].StageSpan;
                if (now > accumulatedTime)
                    continue;

                if (model.CurrentStage != i)
                {
                    model.CurrentStage = i;
                    _model.Refresh();
                }
                return;
            }

            var lastStage = model.BaseModel.Stages.Count - 1;
            if (model.CurrentStage != lastStage)
            {
                model.CurrentStage = lastStage;
                _model.Refresh();
            }
        }
    }
}
