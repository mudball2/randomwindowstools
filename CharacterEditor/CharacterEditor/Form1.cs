using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharacterEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox4.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addCharacterToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Character c = new Character();
            c.Name = textBox1.Text;
            c.PlaceOfBirth = textBox2.Text;
            c.Intellect = numericUpDown4.Value;
            c.Stamina = numericUpDown3.Value;
            c.Spirit = numericUpDown5.Value;
            c.Strength = numericUpDown1.Value;
            c.Agility = numericUpDown2.Value;

            //Add the advanced attributes
            //c.DefenseAttributes.Armor = numericUpDown6.Value;

            listBox1.Items.Add(c);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Character c = (Character)listBox1.Items[listBox1.SelectedIndex];
        
            textBox1.Text = c.Name;
            textBox2.Text = c.PlaceOfBirth;
            numericUpDown4.Value = c.Intellect;
            numericUpDown3.Value = c.Stamina;
            numericUpDown5.Value = c.Spirit;
            numericUpDown1.Value = c.Strength;
            numericUpDown2.Value = c.Agility;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Advanced Editor...")
            {
                button1.Text = "Basic Editor";
                groupBox4.Show();
            }
            else
            {
                button1.Text = "Advanced Editor...";
                groupBox4.Hide();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "All Files(*.*)|*.*|My Files(*.txt)|*.txt";
            dlg.DefaultExt = "txt";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(dlg.FileName);
                writer.WriteLine(textBox1.Text);
                writer.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All Files(*.*)|*.*|My Files(*.txt)|*.txt";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(dlg.FileName);
                textBox1.Text = reader.ReadLine();
                reader.Close();
            }
        }
    }
}
