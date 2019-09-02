using System;
using System.Drawing;
using System.Windows.Forms;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.UserControls.Pages
{
    public partial class Customize : UserControl
    {
        private RegistryManager registryManager;

        public Customize()
        {
            InitializeComponent();

            registryManager = new RegistryManager();

            #region StyleConfiguration

            var styleConfig = registryManager.GetStyleConfiguration();
            colorGrid1.Color = ColorTranslator.FromHtml(styleConfig.TextColor);

            foreach (FontFamily font in FontFamily.Families)
            {
                ComboboxFont.Items.Add(font.Name);
            }

            ComboboxFont.SelectedItem = styleConfig.FontFamily;
            if (styleConfig.Icon == IconStyle.Arrow) radioPictArrow.Checked = true;
            else if (styleConfig.Icon == IconStyle.TriangleArrow) radioPictTriangleArrow.Checked = true;
            else if (styleConfig.Icon == IconStyle.Outline_Arrow) radioPictOutline.Checked = true;

            if (ComboboxFont.Items.Contains("")) ComboboxFont.Items.Remove("");

            ToggleAdaptive.Checked = styleConfig.Adaptive;

            var isAdaptiveChecked = ToggleAdaptive.Checked ? colorGrid1.Enabled = false : colorGrid1.Enabled = true;

            #endregion StyleConfiguration
        }

        private void Customize_Load(object sender, EventArgs e)
        {
        }

        private void BtnSaveStyle_Click(object sender, EventArgs e)
        {
            if (ComboboxFont.SelectedItem != null)
            {
                StyleConfiguration styleConfiguration = new StyleConfiguration
                {
                    Adaptive = ToggleAdaptive.Checked,
                    TextColor = ColorTranslator.ToHtml(colorGrid1.Color),
                    FontFamily = ComboboxFont.SelectedItem.ToString()
                };

                if (radioPictArrow.Checked == true) styleConfiguration.Icon = IconStyle.Arrow;
                else if (radioPictTriangleArrow.Checked == true) styleConfiguration.Icon = IconStyle.TriangleArrow;
                else if (radioPictOutline.Checked == true) styleConfiguration.Icon = IconStyle.Outline_Arrow;

                registryManager.Save(styleConfiguration);
            }
            else
            {
                MessageBox.Show(this, "You have not chosen font style", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                NativeMethods.PostMessage(new IntPtr(Convert.ToInt32(registryManager.GetHwnd())), NativeMethods.WM_RESTART, IntPtr.Zero, IntPtr.Zero);
            }
            catch { }
        }

        private void ToggleAdaptive_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ToggleAdaptive.Checked ? colorGrid1.Enabled = false : colorGrid1.Enabled = true;
        }
    }
}