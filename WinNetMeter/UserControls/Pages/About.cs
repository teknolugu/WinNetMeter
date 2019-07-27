using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WinNetMeter.UserControls.Pages
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        #region Link

        private void LinkArfan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/MArfan890");
        }

        private void LinkAzhe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/azhe403");
        }

        private void LinkJeremy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/SiiJere");
        }

        private void LinkJovan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/jovanzers");
        }

        private void LinkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.winten.tk");
        }

        private void LinkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/WinTenDev");
        }

        private void LinkDonation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FWM2D25VHMERG&source=url");
        }

        #endregion

        private void About_Load(object sender, EventArgs e)
        {
            var assemblyInfo = Assembly.GetExecutingAssembly();
            var assemblyCompany = assemblyInfo
            .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
            .OfType<AssemblyCompanyAttribute>()
            .FirstOrDefault();

            lblVersion.Text = "v" + Application.ProductVersion;
            lblCopyright.Text = "Copyright © 2019 " + assemblyCompany.Company;
        }
    }
}
