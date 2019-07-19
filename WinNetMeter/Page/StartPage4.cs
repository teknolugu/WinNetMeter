using System;
using System.Windows.Forms;

namespace WinNetMeter.Page
{
    public partial class StartPage4 : UserControl
    {
        private static bool joinDevelopment;

        public static bool JoinDevelopment { get => joinDevelopment; set => joinDevelopment = value; }

        public StartPage4()
        {
            InitializeComponent();
        }

        private void CheckJoinDevelopment_CheckedChanged(object sender, EventArgs e)
        {
            joinDevelopment = checkJoinDevelopment.Checked;
        }
    }
}
