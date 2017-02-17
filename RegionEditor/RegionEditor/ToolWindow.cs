using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegionEditor
{
    public partial class ToolWindow : Form
    {
        public event EventHandler UpdateRegion;

        public ToolWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UpdateRegion != null)
            {
                UpdateRegion(this, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = button1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                button1.BackColor = dlg.Color;
            }
        }
    }
}
