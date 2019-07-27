using System;
using System.Drawing;
using System.Windows.Forms;
using WinNetMeter.Helper;
using WinNetMeter.Model;

namespace WinNetMeter.UserControls.Pages
{
    public partial class Customize : UserControl
    {
        private RegistryManager registryManager = new RegistryManager();

        public Customize()
        {
            InitializeComponent();

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
                    TextColor = ColorTranslator.ToHtml(colorGrid1.Color),
                    FontFamily = ComboboxFont.SelectedItem.ToString(),
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
    }
}