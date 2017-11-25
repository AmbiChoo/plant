﻿using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace WeatherPlant.Service
{
    public class WeatherService : MonoBehaviour
    {
        private class Request
        {
            public bool IsComplete;
            public Action<Weather> Callback;
            public Weather Data;
            public Thread RequestThread;
        }

        private Queue<Request> _queue = new Queue<Request>();

        public void GetWeather(Action<Weather> callback)
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
            var httpRequest = (HttpWebRequest)WebRequest.Create("http://samples.openweathermap.org/data/2.5/weather?zip=94030,us&appid=88eac2195d58d6259219d1224bfb43b8");

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            var responseStream = httpResponse.GetResponseStream();
            var streamReader = new StreamReader(responseStream, Encoding.UTF8);

            var data = streamReader.ReadToEnd();
            var parsedData = JsonConvert.DeserializeObject<Weather>(data);

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