using System;
using System.Collections.Generic;
using UnityEngine;
using WeatherPlant.Weather.Models;
using WeatherPlant.Weather.ViewModel;
using WeatherPlant.BaseMVC;

namespace WeatherPlant.Weather.View
{
    public class CurrentConditionView : BaseView<WeatherModel, WeatherViewModel>
    {
        [Serializable]
        private class ConditionGroup
        {
            public int[] ConditionIDs;
            public GameObject[] Targets;
        }

        [SerializeField]
        private List<ConditionGroup> _conditionsGroup;

        protected override void UpdateView(WeatherModel data)
        {
            DisableAll();

            var conditionID = data.Conditions[0].ID;
            var objects = FindConditionID(conditionID);
            EnableObjects(objects, true);
        }

        private void DisableAll()
        {
            for (int i = 0; i < _conditionsGroup.Count; ++i)
            {
                var group = _conditionsGroup[i];
                EnableObjects(group.Targets, false);
            }
        }

        private void EnableObjects(GameObject[] targets, bool enable)
        {
            if (targets == null)
                return;
            for (int i = 0; i < targets.Length; ++i)
            {
                targets[i].SetActive(enable);
            }
        }

        public GameObject[] FindConditionID(int id)
        {
            for (int i = 0; i < _conditionsGroup.Count; ++i)
            {
                var group = _conditionsGroup[i];
                for (int o = 0; o < group.ConditionIDs.Length; ++o)
                {
                    if (group.ConditionIDs[o] == id)
                        return group.Targets;
                }
            }

            return null;
        }
    }
}
