using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinNetMeter.Core.Helper;
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
            if (ThisApp.IsUwpApp())
            {
                Text += " (UWP)";
            }
        }

        #region custom

        private void BtnGeneral_Click(object sender, EventArgs e)
        {
            setSelected(BtnGeneral);
            LblTitlePages.Text = (sender as Button).Text.Trim();
            TabMainMenu.SelectedTab = tabPage1;
        }

        private void BtnIntegrate_Click(object sender, EventArgs e)
        {
            setSelected(BtnIntegrate);
            LblTitlePages.Text = (sender as Button).Text.Trim();
            TabMainMenu.SelectedTab = tabPage4;
        }

        private void BtnCustomization_Click(object sender, EventArgs e)
        {
            setSelected(BtnCustomization);
            LblTitlePages.Text = (sender as Button).Text.Trim();
            TabMainMenu.SelectedTab = tabPage2;
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
        }

        private void BtnDatabase_Click(object sender, EventArgs e)
        {
            setSelected(BtnDatabase);
            LblTitlePages.Text = (sender as Button).Text.Trim();
            TabMainMenu.SelectedTab = tabPage3;
        }

        private void BtnUpdateRecovery_Click(object sender, EventArgs e)
        {
            setSelected(btnUpdateRecovery);
            LblTitlePages.Text = (sender as Button).Text.Trim();
            TabMainMenu.SelectedTab = tabUpdateRecovery;
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            setSelected(BtnAbout);
            LblTitlePages.Text = (sender as Button).Text.Trim();
            TabMainMenu.SelectedTab = tabPage5;
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

            RegistryManager registryManager = new RegistryManager();
            registryManager.WriteToRegistry("WinNetMeter", "AppBasePath", Environment.CurrentDirectory);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TabMainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
        }
    }
}