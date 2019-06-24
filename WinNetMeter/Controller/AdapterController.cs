using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WinNetMeter.Helper;

namespace WinNetMeter.Controller
{
    class AdapterController : NetworkIntefaceModule
    {
        private string name;
        private long FirstDownloadValue, FirstUploadValue;
        private long DownloadValue, UploadValue;
        private long downloadSpeed, uploadSpeed;
        public PerformanceCounter DownloadSpeedCounter, UploadSpeedCounter;

        public string AdapaterName { get => name; set => name = value; }
        public long DownloadSpeed { get => downloadSpeed; set => downloadSpeed = value; }
        public long UploadSpeed { get => uploadSpeed; set => uploadSpeed = value; }

        public double UploadSpeedKBps { get => this.uploadSpeed / 1024.0; }

        public double DownloadSpeedKBps { get => this.downloadSpeed / 1024.0; }

        public double UploadSpeedMBps { get => (this.uploadSpeed / 1024.0) / 1024.0; }

        public double DownloadSpeedMBps { get => (this.downloadSpeed / 1024.0) / 1024.0; }

        internal AdapterController(string adapterName){
            AdapaterName = adapterName;
        }

        public void Initialize()
        {
            this.FirstDownloadValue = DownloadSpeedCounter.NextSample().RawValue;
            this.FirstUploadValue = UploadSpeedCounter.NextSample().RawValue;
        }

        public void Refresh()
        {
            this.DownloadValue = DownloadSpeedCounter.NextSample().RawValue;
            this.UploadValue = UploadSpeedCounter.NextSample().RawValue;

            this.DownloadSpeed = DownloadValue - FirstDownloadValue;
            this.uploadSpeed = UploadValue - FirstUploadValue;

            UpdateFirstValue();
        }
       public void UpdateFirstValue()
        {
            this.FirstDownloadValue = DownloadSpeedCounter.NextSample().RawValue;
            this.FirstUploadValue = UploadSpeedCounter.NextSample().RawValue;
        }
    }
}
