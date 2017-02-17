using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegionEditor
{
    public partial class Form1 : Form
    {
        ToolWindow tool = null; //Initialize Tool Window
        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Rectangle")
            {
                Graphics gp = graphicsPanel1.CreateGraphics();
                Rectangle rect = graphicsPanel1.ClientRectangle;
                rect.X = (int)numericUpDown1.Value;
                rect.Y = (int)numericUpDown2.Value;
                rect.Width = (int)numericUpDown3.Value;
                rect.Height = (int)numericUpDown4.Value;
                Brush brush = new LinearGradientBrush(rect, button1.BackColor, button1.BackColor, LinearGradientMode.Vertical);

                Pen pen = new Pen(Color.FromArgb(255, 255, 255));
                pen.Width = 1f;

                gp.DrawRectangle(pen, rect);
                gp.FillRectangle(brush , rect);
               // graphicsPanel1.Invalidate(); May not need this for now, it's just erasing last thing painted.

                //brush.Dispose();
                
            }
            else if(comboBox1.Text == "Ellipse")
            {
                Graphics gp = graphicsPanel1.CreateGraphics();
                Rectangle rect = graphicsPanel1.ClientRectangle;
                rect.X = (int)numericUpDown1.Value;
                rect.Y = (int)numericUpDown2.Value;
                rect.Width = (int)numericUpDown3.Value;
                rect.Height = (int)numericUpDown4.Value;
                Brush brush = new LinearGradientBrush(rect, button1.BackColor, button1.BackColor, LinearGradientMode.Vertical);

                Pen pen = new Pen(Color.FromArgb(255, 255, 255));
                pen.Width = 1f;

                gp.DrawEllipse(pen, rect);
                gp.FillEllipse(brush, rect);
            }
        }

        private void regionToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tool == null)
            {
                tool = new ToolWindow();
                tool.FormClosed += new FormClosedEventHandler(tool_FormClosed);
                tool.UpdateRegion += new EventHandler(tool_UpdateRegion);


                tool.Show(this);
            }
        }

        void tool_UpdateRegion(object sender, EventArgs e)
        {
            ToolWindow toolTemp = (ToolWindow)sender;


        }

        void tool_FormClosed(object sender, FormClosedEventArgs e)
        {
            tool = null;
        }
    }
}
