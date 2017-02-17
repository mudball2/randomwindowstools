using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileEditor
{
    public partial class ToolWindow : Form
    {
        public event ApplyEventHandler optionApply;
        public event ApplyEventHandler optionOK;

        public ToolWindow()
        {
            InitializeComponent();
        }

        public int NumericUpDownMapWidth
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public int NumericUpDownMapHeight
        {
            get { return (int)numericUpDown2.Value; }
            set { numericUpDown2.Value = value; }
        }

        public int NumericUpDownTileSetWidth
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown3.Value = value; }
        }

        public int NumericUpDownTileSetHeight
        {
            get { return (int)numericUpDown4.Value; }
            set { numericUpDown4.Value = value; }
        }

        public int NumericUpDownTileSizeWidth
        {
            get { return (int)numericUpDown5.Value; }
            set { numericUpDown5.Value = value; }
        }

        public int NumericUpDownTileSizeHeight
        {
            get { return (int)numericUpDown6.Value; }
            set { numericUpDown6.Value = value; }
        }

         public delegate void ApplyEventHandler(object sender, ApplyEventArgs e);

        public class ApplyEventArgs : EventArgs
        {
            int mapSizeWidth;
            int mapSizeHeight;
            int tileSetSizeWidth;
            int tileSetSizeHeight;
            int tileSizeWidth;
            int tileSizeHeight;

            public int MapSizeWidth
            {
                get { return mapSizeWidth; }
                set { mapSizeWidth = value; }
            }
            
            public int MapSizeHeight
            {
                get { return mapSizeHeight; }
                set { mapSizeHeight = value; }
            }
            
            public int TileSetSizeWidth
            {
                get { return tileSetSizeWidth; }
                set { tileSetSizeWidth = value; }
            }
            
            public int TileSetSizeHeight
            {
                get { return tileSetSizeHeight; }
                set { tileSetSizeHeight = value; }
            }

            public int TileSizeWidth
            {
                get { return tileSizeWidth; }
                set { tileSizeWidth = value; }
            }
            
            public int TileSizeHeight
            {
                get { return tileSizeHeight; }
                set { tileSizeHeight = value; }
            }

            public ApplyEventArgs(int mapWidth, int mapHeight, int tileSetSizeWidth, int tileSetSizeHeight, int tileSizeWidth, int tileSizeHeight)
            {
                this.mapSizeWidth = mapWidth;
                this.mapSizeHeight = mapHeight;
                this.tileSetSizeWidth = tileSetSizeWidth;
                this.tileSetSizeHeight = tileSetSizeHeight;
                this.tileSizeWidth = tileSizeWidth;
                this.tileSizeHeight = tileSizeHeight;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (optionOK != null)
            {
                optionOK(this, new ApplyEventArgs(this.NumericUpDownMapWidth, this.NumericUpDownMapHeight,
                                                  this.NumericUpDownTileSetWidth, this.NumericUpDownTileSetHeight,
                                                  this.NumericUpDownTileSizeWidth, this.NumericUpDownTileSizeHeight));
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (optionApply != null)
            {
                optionApply(this, new ApplyEventArgs(this.NumericUpDownMapWidth, this.NumericUpDownMapHeight,
                                                     this.NumericUpDownTileSetWidth, this.NumericUpDownTileSetHeight,
                                                     this.NumericUpDownTileSizeWidth, this.NumericUpDownTileSizeHeight));
            }
        }
    }
}
