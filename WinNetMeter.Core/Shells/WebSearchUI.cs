using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNetMeter.Core.Shells
{
    public partial class WebSearchUI : UserControl
    {
        public WebSearchUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://google.com#q=" + textBox1.Text);
        }
    }
}