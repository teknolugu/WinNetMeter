using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using WinNetMeter.Core;
using WinNetMeter.Helper;

namespace WinNetMeter
{
    public partial class Main : Form
    {
        private static Main main;

        private static FormWindowState state;

        public static FormWindowState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;

                if (value == FormWindowState.Minimized)
                {
                    main.WindowState = FormWindowState.Minimized;
                }
            }
        }

        public Main()
        {
            InitializeComponent();
            CleaningOnStartup();

            main = this;
            State = this.WindowState;
        }

       

        #region custom

        private void BtnGeneral_Click(object sender, EventArgs e)
        {
            setSelected(BtnGeneral);
            LblTitlePages.Text = "General";
            tabControl1.SelectedTab = tabPage1;
        }

        private void BtnIntegrate_Click(object sender, EventArgs e)
        {
            setSelected(BtnIntegrate);
            LblTitlePages.Text = "Integrate";
            tabControl1.SelectedTab = tabPage4;
        }

        private void BtnCustomization_Click(object sender, EventArgs e)
        {
            setSelected(BtnCustomization);
            LblTitlePages.Text = "Customization";
            tabControl1.SelectedTab = tabPage2;
        }

        private void setSelected(Button selectedBtn)
        {
            PnlSelector.Location = new Point(0, selectedBtn.Location.Y);

            foreach (Button button in PanelMainMenu.Controls.OfType<Button>())
            {
                if (button == selectedBtn)
                {
                    selectedBtn.BackColor = ColorTranslator.FromHtml("#F0F0F0");
                }
                else
                {
                    button.BackColor = Color.Transparent;
                }
            }

            //btn1.BackColor = Color.Transparent;
            //btn2.BackColor = Color.Transparent;
            //btn3.BackColor = Color.Transparent;
            //btn4.BackColor = Color.Transparent;
            //btnUpdateRecovery.BackColor = Color.Transparent;
        }

        private void BtnDatabase_Click(object sender, EventArgs e)
        {
            setSelected(BtnDatabase);
            LblTitlePages.Text = "Database";
            tabControl1.SelectedTab = tabPage3;
        }

        private void BtnUpdateRecovery_Click(object sender, EventArgs e)
        {
            setSelected(btnUpdateRecovery);
            LblTitlePages.Text = "Update & Recovery";
            tabControl1.SelectedTab = tabUpdateRecovery;
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            setSelected(BtnAbout);
            LblTitlePages.Text = "About";
            tabControl1.SelectedTab = tabPage5;
        }

        #endregion custom

        private void Main_Load(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            try
            {
                if (args[1] == "-about")
                {
                    BtnAbout.PerformClick();
                }
            }
            catch { }
        }

        private void CleaningOnStartup()
        {
            PanelMainMenu.Width = 247;
            Integration integration = new Integration();
            integration.MakeUninstaller();

            FileHelper.DeleteAllIn(Environment.CurrentDirectory, "*.old");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}