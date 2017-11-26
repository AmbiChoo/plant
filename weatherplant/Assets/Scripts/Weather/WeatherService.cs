using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using WeatherPlant.Weather.Models;

namespace WeatherPlant.Service
{
    public class WeatherService : MonoBehaviour
    {
        private class Request
        {
            public bool IsComplete;
            public Action<WeatherModel> Callback;
            public WeatherModel Data;
            public Thread RequestThread;
        }

        private Queue<Request> _queue = new Queue<Request>();

        public void GetWeather(Action<WeatherModel> callback)
        {
            var request = new Request()
            {
                IsComplete = false,
                Callback = callback
            };

            _queue.Enqueue(request);

            // Execute Thread
            request.RequestThread = new Thread(ProcessRequest);
            request.RequestThread.Start();
        }

        private void ProcessRequest()
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?zip=94030,us&appid=88eac2195d58d6259219d1224bfb43b8");

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            var responseStream = httpResponse.GetResponseStream();
            var streamReader = new StreamReader(responseStream, Encoding.UTF8);

            var data = streamReader.ReadToEnd();
            var parsedData = JsonConvert.DeserializeObject<WeatherModel>(data);

            // Check request
            var request = _queue.Peek();
            request.Data = parsedData;
            request.IsComplete = true;
        }

        private void Update()
        {
            if (_queue.Count <= 0)
                return;
            if (!_queue.Peek().IsComplete)
                return;

            var request = _queue.Dequeue();
            request.Callback.Invoke(request.Data);
        }
    }
}
