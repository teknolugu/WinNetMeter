using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using WinNetMeter.Model;

namespace WinNetMeter.Helper
{
    internal class Updater
    {
        private readonly string baseUrl = "https://cdn.winten.space";
        private readonly string urlUpdateConfig = "";
        private readonly string updaterConfig = "update-config.json";
        private WebClient client;
        private Update update;

        internal Updater()
        {
            urlUpdateConfig = $"{baseUrl}/products/win-netmeter/release/{updaterConfig}";
          
        }


        public bool IsUpdateAvailable()
        {
            bool Available = false;
            client = new WebClient();
            var data = client.DownloadString(urlUpdateConfig);

            update = JsonConvert.DeserializeObject<Update>(data);

            // Compare dashboard version
            Version currentVersion = new Version(Application.ProductVersion);
            Version latestDashboardVersion = new Version(update.DashboardVersion);

            var comparison = currentVersion.CompareTo(latestDashboardVersion);

            if (comparison < 0)
            {
                Available = true;
            }

            return Available;
        }

        public string getDashboardVersion()
        {
            return update.DashboardVersion;
        }


        public List<string> getChangelog()
        {
            return update.Changelog;
        }

        public void createFile()
        {
            File.Create("test.json").Close();
            Update update = new Update()
            {
                DashboardVersion = "1.0",
                Changelog = new List<string>()
                {
                    "ewoasdasd",
                    "asdasdasd"
                }
            };

            var json = JsonConvert.SerializeObject(update);
            File.WriteAllText("test.json", json);
        }
    }
}