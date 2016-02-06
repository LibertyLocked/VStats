﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GTA;
using Newtonsoft.Json;

namespace VStats_plugin
{
    class MainScript : Script
    {
        private readonly string url;
        private readonly int sleepTime;

        //private SemaphoreSlim PostDataSemaphore = new SemaphoreSlim(1, 1);
        Object lockThis = new Object();
        bool isStopped;
        GameData cacheData;
        ConcurrentQueue<WebInput> inputQueue;

        public MainScript()
        {
            // SETUP
            var settings = ScriptSettings.Load(@".\scripts\VStats.ini");
            string port = settings.GetValue("Core", "PORT", "8080");
            int interval = settings.GetValue("Core", "INTERVAL", 10);
            url = "http://localhost:" + port + "/push";
            sleepTime = interval;

            this.inputQueue = new ConcurrentQueue<WebInput>();
            this.isStopped = true;
            this.Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (isStopped)
            {
                Thread workerThread = new Thread(ThreadProc_PostJSON);
                workerThread.Start();
            }
            cacheData = GameData.GetData();
            
            // Check for inputs
            WebInput input;
            if (inputQueue.TryDequeue(out input))
            {
                try
                {
                    input.Execute();
                }
                catch
                {
                    UI.Notify("VStats func failed: " + input.Cmd + " " + input.Arg);
                }
            }
        }

        private void ThreadProc_PostJSON()
        {
            lock (lockThis)
            {
                isStopped = false;
                while (true)
                {
                    try
                    {
                        using (var client = new WebClient())
                        {
                            var values = new NameValueCollection();
                            values["d"] = JsonConvert.SerializeObject(cacheData);
                            var response = client.UploadValues(url, values);
                            // Read response
                            if (response != null && response.Length > 0)
                            {
                                WebInput input = JsonConvert.DeserializeObject<WebInput>(Encoding.ASCII.GetString(response));
                                if (input != null)
                                {
                                    inputQueue.Enqueue(input);
                                    Logger.Log(Encoding.ASCII.GetString(response));
                                }
                            }
                        }
                    }
                    catch
                    {
                        Thread.Sleep(100);
                        //throw;
                    }
                    Thread.Sleep(sleepTime);
                }
                //isStopped = true;
            }
        }
    }
}
