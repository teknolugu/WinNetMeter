using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinNetMeter.Page;
using WinNetMeter.Helper;
using System.Windows.Forms;

namespace WinNetMeter
{
    public partial class Setup : Form
    {
        public static int page = 1;
        private RegistryManager settingsManager = new RegistryManager();

        public Setup()
        {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            StartPage1 page1 = new StartPage1();
            page1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page1);

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            StartPage3 page3 = new StartPage3();
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
                page3.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(page3);

                panelContainer.Controls["StartPage3"].BringToFront();
                page = 3;
            }
            else if (page == 3)
            {
                Properties.Settings.Default.FirstLaunch = false;
                Properties.Settings.Default.Save();
                if (StartPage3.SelectedAdapter != null)
                {
                    settingsManager.Save("MonitoredAdapter", StartPage3.SelectedAdapter, Model.ConfigurationType.GeneralConfiguration);
                    Hide();
                    Main main = new Main();
                    main.Show();
                }
                else MessageBox.Show(this, "You have not chosen the network adapter", "Ooopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //else
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

        enum MoveLabel{
            Right,
            Left
        }

        private void LinkBack_Click(object sender, EventArgs e)
        {
            if(page == 2)
            {
                page = 1;
                panelContainer.Controls["StartPage1"].BringToFront();
                moveProductTitle(MoveLabel.Left);
            }else if(page == 3)
            {
                page = 2;
                panelContainer.Controls["StartPage2"].BringToFront();
            }
        }
    }
}
