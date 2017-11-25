using System;
using Newtonsoft.Json;

namespace WeatherPlant.Plant.Models
{
    public class PlantStage
    {
        [JsonProperty("stage_span")]
        private TimeSpan _stageSpan;

        /// <summary>
        /// Time Span of this stage
        /// </summary>
        /// <value>Stage span.</value>
        public TimeSpan StageSpan
        {
            get { return _stageSpan; }
        }
    }
}
