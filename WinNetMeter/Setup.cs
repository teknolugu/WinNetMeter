using System;
using System.Drawing;
using System.Windows.Forms;
using WinNetMeter.Helper;
using WinNetMeter.Page;

namespace WinNetMeter
{
    public partial class Setup : Form
    {
        private static bool btnNextEnabled;

        private static Setup setup;

        public static bool BtnNextEnabled
        {
            get
            {
                return btnNextEnabled;
            }
            set
            {
                btnNextEnabled = value;
                setup.btnNext.Enabled = value;
            }
        }

        public static string BtnNextEnabledText
        {
            get
            {
                return setup.btnNext.Text;
            }
            set
            {
                setup.btnNext.Text = value;
            }
        }

        public static int page = 1;
        private RegistryManager settingsManager = new RegistryManager();

        public Setup()
        {
            InitializeComponent();
            setup = this;
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            StartPage1 page1 = new StartPage1();
            page1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page1);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (page == 1 && panelContainer.Controls.ContainsKey("StartPage2"))
            {
                panelContainer.Controls["StartPage2"].BringToFront();
                moveProductTitle(MoveLabel.Right);
                page = 2;
            }
            else if (page == 2 && panelContainer.Controls.ContainsKey("StartPage3"))
            {
                panelContainer.Controls["StartPage3"].BringToFront();
                page = 3;
            }
            else if (page == 3 && panelContainer.Controls.ContainsKey("StartPage4"))
            {
                panelContainer.Controls["StartPage4"].BringToFront();
                page = 4;
            }
            else if (page == 4 && panelContainer.Controls.ContainsKey("StartPage5"))
            {
                panelContainer.Controls["StartPage5"].BringToFront();
                page = 5;
            }
            else if (page == 1 && panelContainer.Controls.ContainsKey("StartPage2") == false)
            {
                StartPage2 page2 = new StartPage2();
                page2.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(page2);

                panelContainer.Controls["StartPage2"].BringToFront();
                moveProductTitle(MoveLabel.Right);
                page = 2;
            }
            else if (page == 2 && panelContainer.Controls.ContainsKey("StartPage3") == false)
            {
                StartPage3 page3 = new StartPage3();
                page3.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(page3);

                panelContainer.Controls["StartPage3"].BringToFront();
                page = 3;
            }
            else if (page == 3 && panelContainer.Controls.ContainsKey("StartPage4") == false)
            {
                if (StartPage3.SelectedAdapter != null)
                {
                    settingsManager.Save("MonitoredAdapter", StartPage3.SelectedAdapter, Model.ConfigurationType.GeneralConfiguration);

                    StartPage4 page4 = new StartPage4();
                    page4.Dock = DockStyle.Fill;
                    panelContainer.Controls.Add(page4);

                    panelContainer.Controls["StartPage4"].BringToFront();
                    page = 4;
                }
                else MessageBox.Show(this, "You have not chosen the network adapter", "Ooopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (page == 4 && panelContainer.Controls.ContainsKey("StartPage5") == false)
            {
                StartPage5 page5 = new StartPage5();
                page5.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(page5);

                panelContainer.Controls["StartPage5"].BringToFront();
                page = 5;
            }
            else if (page == 5)
            {
                Properties.Settings.Default.FirstLaunch = false;
                Properties.Settings.Default.Save();
                Hide();

                Main main = new Main();
                main.Show();

                if (StartPage4.JoinDevelopment) System.Diagnostics.Process.Start("https://github.com/WinTenDev/WinNetMeter");
            }
        }

        private void moveProductTitle(MoveLabel move)
        {
            switch (move)
            {
                case MoveLabel.Right:
                    lblProductName.Location = new Point(47, 11);
                    lblProductDesc.Location = new Point(176, 13);
                    break;

                case MoveLabel.Left:
                    lblProductName.Location = new Point(12, 11);
                    lblProductDesc.Location = new Point(139, 13);
                    break;
            }
        }

        private enum MoveLabel
        {
            Right,
            Left
        }

        private void LinkBack_Click(object sender, EventArgs e)
        {
            if (page == 2)
            {
                page = 1;
                panelContainer.Controls["StartPage1"].BringToFront();
                moveProductTitle(MoveLabel.Left);
            }
            else if (page == 3)
            {
                page = 2;
                panelContainer.Controls["StartPage2"].BringToFront();
            }
            else if (page == 4)
            {
                page = 3;
                panelContainer.Controls["StartPage3"].BringToFront();
            }
            else if (page == 5)
            {
                page = 4;
                panelContainer.Controls["StartPage4"].BringToFront();
            }
        }
    }
}