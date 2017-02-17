using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace TileEditor
{
    public partial class Form1 : Form
    {

        Size tileSetSize = new Size(4, 2);
        Size tileSize = new Size(64, 64);
        Size mapSize = new Size(5, 5);

        Point[,] map = new Point[5, 5];

        Bitmap tileSet = Properties.Resources._default;

        Point selectedTile = new Point(0, 0);

        ToolWindow option = null; 
        public Form1()
        {
            InitializeComponent();

            splitContainer1.Panel1.AutoScrollMinSize = tileSet.Size;

            splitContainer1.Panel2.AutoScrollMinSize = new Size(mapSize.Width * tileSize.Width,
                mapSize.Width * tileSize.Width);

            map = new Point[mapSize.Width, mapSize.Height];

            graphicsPanel2.Invalidate();
        }

        private void graphicsPanel2_Paint(object sender, PaintEventArgs e)
        {
            Point offset = new Point(0, 0);

            offset.X += splitContainer1.Panel1.AutoScrollPosition.X;
            offset.Y += splitContainer1.Panel2.AutoScrollPosition.Y;

            e.Graphics.DrawImage(tileSet, offset);
            // e.Graphics.DrawRectangle(Pens.Red, Rectangle.Empty);

            for (int x = 0; x < tileSetSize.Width; x++)
            {
                for (int y = 0; y < tileSetSize.Height; y++)
                {
                    Rectangle rect = Rectangle.Empty;

                    rect.X = x * tileSize.Width + offset.X;
                    rect.Y = y * tileSize.Height + offset.Y;

                    rect.Size = tileSize;

                    Point selectedPoint = new Point(0, 0);
                    selectedPoint.X = selectedTile.X * tileSize.Width + offset.X;
                    selectedPoint.Y = selectedTile.Y * tileSize.Height + offset.Y;
                    if (rect.Contains(selectedPoint))
                    {
                        Pen pen = new Pen(Color.Black);
                        pen.Width = 5f;

                        e.Graphics.DrawRectangle(pen, rect);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, rect);
                    }
                }
            }
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            Point offset = new Point(0, 0);

            offset.X += splitContainer1.Panel2.AutoScrollPosition.X;
            offset.Y += splitContainer1.Panel2.AutoScrollPosition.Y;

            for (int i = 0; i < mapSize.Width; i++)
            {
                for (int j = 0; j < mapSize.Height; j++)
                {
                    Rectangle destRect = Rectangle.Empty;
                    destRect.X = i * tileSize.Width;
                    destRect.Y = j * tileSize.Height;
                    destRect.Size = tileSize;

                    Rectangle srcRect = Rectangle.Empty;
                    srcRect.X = map[i, j].X * tileSize.Width;
                    srcRect.Y = map[i, j].Y * tileSize.Height;
                    srcRect.Size = tileSize;

                    e.Graphics.DrawImage(tileSet, destRect, srcRect, GraphicsUnit.Pixel);

                    e.Graphics.DrawRectangle(Pens.Black, destRect);
                }
            }
        }

        private void graphicsPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            selectedTile.X = e.X / tileSize.Width;
            selectedTile.Y = e.Y / tileSize.Height;

            graphicsPanel2.Invalidate();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / tileSize.Width;
            int y = e.Y / tileSize.Height;

            if (x < mapSize.Width && y < mapSize.Height) //Safe check so it doesn't crash.
                map[x, y] = selectedTile;

            graphicsPanel1.Invalidate();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tileSet = Properties.Resources._default;

            tileSetSize = new Size(4, 2);
            tileSize = new Size(64, 64);
            mapSize = new Size(5, 5);

            selectedTile = new Point(0, 0);
            map = new Point[5, 5];

            option = null;

            splitContainer1.Panel1.AutoScrollMinSize = new Size(tileSetSize.Width * tileSize.Width,
                tileSetSize.Height * tileSize.Height);
            splitContainer1.Panel2.AutoScrollMinSize = new Size(mapSize.Width * tileSize.Width,
                mapSize.Width * tileSize.Width);

            graphicsPanel1.Invalidate();
            graphicsPanel2.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files|*.*|Text Files|*.txt";
            save.FilterIndex = 2;
            save.DefaultExt = ".txt";

            using (Bitmap b = new Bitmap(50, 50)) { using (Graphics g = Graphics.FromImage(b)) { g.Clear(Color.Green); } b.Save(@"C:\green.png", ImageFormat.Png); }

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(save.FileName))
                {
                    string str1 = string.Empty;
                    Size size = tileSize;
                    string str2 = size.Width.ToString();
                    string str3 = ",";
                    string str4 = str1 + str2 + str3;

                    size = tileSize;
                    string str5 = size.Height.ToString();
                    string str6 = ",";
                    string str7 = str4 + str5 + str6;

                    size = tileSetSize;
                    string str8 = size.Width.ToString();
                    string str9 = ",";
                    string str10 = str7 + str8 + str9;

                    size = tileSetSize;
                    string str11 = size.Height.ToString();
                    string str12 = ",";
                    string str13 = str10 + str11 + str12;

                    size = mapSize;
                    string str14 = size.Width.ToString();
                    string str15 = ",";
                    string str16 = str13 + str14 + str15;

                    size = mapSize;
                    string str17 = size.Height.ToString();
                    string str18 = str16 + str17;

                    streamWriter.WriteLine(str18);
                    int index1 = 0;

                    while (true)
                    {
                        int num1 = index1;
                        Size tempmapSize = mapSize;
                        int height = mapSize.Height;
                        if (num1 < height)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            int index2 = 0;
                            while (true)
                            {
                                int num2 = index2;
                                tempmapSize = mapSize;
                                int width1 = mapSize.Width;
                                if (num2 < width1)
                                {
                                    int temp = map[index2, index1].Y * tileSetSize.Width + map[index2, index1].X;
                                    stringBuilder.Append(temp);

                                    int num3 = index2 + 1;
                                    tempmapSize = mapSize;

                                    int width2 = mapSize.Width;

                                    if (num3 < width2)
                                    {
                                        stringBuilder.Append(',');
                                    }

                                    ++index2;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            streamWriter.WriteLine(((object)stringBuilder).ToString());
                            ++index1;
                        }
                        else
                            break;
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files|*.*|Text Files|*.txt";
            open.FilterIndex = 2;

            if (DialogResult.OK == open.ShowDialog())
            {
                using (StreamReader streamReader = new StreamReader(open.FileName))
                {
                    string str = string.Empty;

                    while (streamReader.Peek() == 47)
                        streamReader.ReadLine();

                    string[] strArray1 = streamReader.ReadLine().Split(new char[1]{ ',' });

                    Size size1 = Size.Empty;
                    Size size2 = Size.Empty;
                    Size size3 = Size.Empty;

                    size1.Width = Convert.ToInt32(strArray1[0]);
                    size1.Height = Convert.ToInt32(strArray1[1]);
                    size2.Width = Convert.ToInt32(strArray1[2]);
                    size2.Height = Convert.ToInt32(strArray1[3]);
                    size3.Width = Convert.ToInt32(strArray1[4]);
                    size3.Height = Convert.ToInt32(strArray1[5]);

                    mapSize = size3;
                    tileSize = size1;
                    tileSetSize = size2;

                    map = new Point[mapSize.Width, mapSize.Height];

                    for (int index1 = 0; index1 < size3.Height; ++index1)
                    {
                        string[] strArray2 = streamReader.ReadLine().Split(new char[1]{ ',' });

                        for (int index2 = 0; index2 < size3.Width; ++index2)
                        {
                            Point point = Point.Empty;

                            point.X = Convert.ToInt32(strArray2[index2]) % this.tileSetSize.Width;
                            point.Y = Convert.ToInt32(strArray2[index2]) / this.tileSetSize.Width;

                            map[index2, index1] = point;
                        }
                    }
                    
                    graphicsPanel1.Invalidate();
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Bmp Files|*.bmp";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                tileSet = new Bitmap(dlg.FileName);

                Graphics g = graphicsPanel2.CreateGraphics();
                tileSet.SetResolution(g.DpiX, g.DpiY);

                splitContainer1.Panel1.AutoScrollMinSize = tileSet.Size;

                graphicsPanel1.Invalidate();
                graphicsPanel2.Invalidate();
            }      
        }

        private void attributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (option == null)
            {
                option = new ToolWindow();

                option.NumericUpDownMapHeight = mapSize.Height;
                option.NumericUpDownMapWidth = mapSize.Width;
                option.NumericUpDownTileSetHeight = tileSetSize.Height;
                option.NumericUpDownTileSetWidth = tileSetSize.Width;
                option.NumericUpDownTileSizeHeight = tileSize.Height;
                option.NumericUpDownTileSizeWidth = tileSize.Width;

                option.FormClosed += new FormClosedEventHandler(option_FormClosed);
                option.optionApply += new ToolWindow.ApplyEventHandler(option_optionApply);
                option.optionOK += new ToolWindow.ApplyEventHandler(option_optionOK);

                if (DialogResult.OK == option.ShowDialog())
                {

                }
            }
        }
        void option_optionOK(object sender, ToolWindow.ApplyEventArgs e)
        {
            Size tempMapSize = new Size(mapSize.Width, mapSize.Height);

            this.mapSize = new Size(e.MapSizeWidth, e.MapSizeHeight);
            this.tileSetSize = new Size(e.TileSetSizeWidth, e.TileSetSizeHeight);
            this.tileSize = new Size(e.TileSizeWidth, e.TileSizeHeight);

            Point[,] tempMap = new Point[tempMapSize.Width, tempMapSize.Height];
            tempMap = map;

            map = new Point[mapSize.Width, mapSize.Height];

            splitContainer1.Panel1.AutoScrollMinSize = new Size(tileSetSize.Width * tileSize.Width, tileSetSize.Height * tileSize.Height);
            splitContainer1.Panel2.AutoScrollMinSize = new Size(mapSize.Width * tileSize.Width, mapSize.Width * tileSize.Width);

            if (tempMapSize.Width > mapSize.Width && tempMapSize.Height > mapSize.Height)
            {
                for (int x = 0; x < mapSize.Width; x++)
                {
                    for (int y = 0; y < mapSize.Height; y++)
                    {
                        map[x, y] = tempMap[x, y];
                    }
                }
            }
            else
            {
                for (int x = 0; x < tempMapSize.Width; x++)
                {
                    for (int y = 0; y < tempMapSize.Height; y++)
                    {
                        map[x, y] = tempMap[x, y];
                    }
                }
            }

            graphicsPanel1.Invalidate();
            graphicsPanel2.Invalidate();
        }

        void option_FormClosed(object sender, FormClosedEventArgs e)
        {
            option = null;
        }

        void option_optionApply(object sender, ToolWindow.ApplyEventArgs e)
        {
            Size tempMapSize = new Size(mapSize.Width, mapSize.Height);

            this.mapSize = new Size(e.MapSizeWidth, e.MapSizeHeight);
            this.tileSetSize = new Size(e.TileSetSizeWidth, e.TileSetSizeHeight);
            this.tileSize = new Size(e.TileSizeWidth, e.TileSizeHeight);

            Point[,] tempMap = new Point[tempMapSize.Width, tempMapSize.Height];
            tempMap = map;

            map = new Point[mapSize.Width, mapSize.Height];

            splitContainer1.Panel1.AutoScrollMinSize = new Size(tileSetSize.Width * tileSize.Width, tileSetSize.Height * tileSize.Height);
            splitContainer1.Panel2.AutoScrollMinSize = new Size(mapSize.Width * tileSize.Width, mapSize.Width * tileSize.Width);

            if (tempMapSize.Width > mapSize.Width && tempMapSize.Height > mapSize.Height)
            {
                for (int x = 0; x < mapSize.Width; x++)
                {
                    for (int y = 0; y < mapSize.Height; y++)
                    {
                        map[x, y] = tempMap[x, y];
                    }
                }
            }
            else
            {
                for (int x = 0; x < tempMapSize.Width; x++)
                {
                    for (int y = 0; y < tempMapSize.Height; y++)
                    {
                        map[x, y] = tempMap[x, y];
                    }
                }
            }

            graphicsPanel1.Invalidate();
            graphicsPanel2.Invalidate();
        }
    }
}
