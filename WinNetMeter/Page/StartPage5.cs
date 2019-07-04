using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using WinNetMeter.Helper;

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

            Integration integration = new Integration();

            ThreadStart threadStart = integration.InstallToolbar;

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
    }
}