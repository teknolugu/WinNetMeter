using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinNetMeter.Page
{
    public partial class StartPage5 : UserControl
    {
        private string batchFileLocation = AppDomain.CurrentDomain.BaseDirectory + @"temp\toolbarInstaller.bat";
        private string FrameworkLocation;
        StreamWriter writer;

        public StartPage5()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void StartPage5_Load(object sender, EventArgs e)
        {
            Setup.BtnNextEnabled = false;

            ThreadStart threadStart = InstallToolbar;

            threadStart += () =>
            {
                Setup.BtnNextEnabled = true;
               
                LabelProgressStatus.Visible = false;
                progressInstaller.Visible = false;
                LblStatus.Text = "Setup Completed";
                Setup.BtnNextEnabledText = "Finish";
            };
            try
            {
                Thread toolBarInstaller = new Thread(threadStart) { IsBackground = true };
                toolBarInstaller.Start();
            }
            catch(Exception ex) {
                MessageBox.Show("An error occured during installing Toolbar item" + Environment.NewLine + ex.Message);
            }

        }

        void WriteBatFile(string value, bool NewLine)
        {
            writer = new StreamWriter(batchFileLocation, true);
            if (NewLine) writer.Write(Environment.NewLine);

            //Write the .bat script
            writer.Write(value);

            //Close the tread
            writer.Close();

        }

        void InstallToolbar()
        {
            //Create .bat file for toolbar installation
            if (!Directory.Exists(Path.GetDirectoryName(batchFileLocation)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(batchFileLocation));
            }
            File.Create(batchFileLocation).Close();

            //Get .NET Framework path Information
            if (Environment.Is64BitOperatingSystem)
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework64\v4.0.30319";
                if (Directory.Exists(FrameworkLocation))
                {
                    WriteBatFile("cd " + FrameworkLocation, false);
                    WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true);
                }
            }
            else
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319";
                if (Directory.Exists(FrameworkLocation))
                {
                    WriteBatFile("cd " + FrameworkLocation, false);
                    WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true);
                }
            }

            //Executing the .bat file
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = Path.GetDirectoryName(batchFileLocation);
            process.FileName = "toolbarInstaller.bat";
            process.Verb = "runas";
            try
            {
                Process.Start(process);
            }
            catch { }
        }
    }
}