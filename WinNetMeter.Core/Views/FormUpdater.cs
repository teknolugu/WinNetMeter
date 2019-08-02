using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNetMeter.Core.Views
{
    public partial class FormUpdater : Form
    {
        public FormUpdater()
        {
            InitializeComponent();
        }

        private void FormUpdater_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
