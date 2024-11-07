using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        double aspect;
        string image_path;
        public Form1()
        {
            InitializeComponent();
            
            LeftSB.Maximum = pictureBox1.Width;
            TopSB.Maximum = pictureBox1.Height;
            pictureBox1.SetBounds(0,0,200,150);
        }

        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.OpenFile() != null)
                {
                    image_path = openFileDialog.FileName;
                    RefreshPictureBox();
                }
            }
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void RefreshPictureBox()
        {
            pictureBox1.Image = Image.FromFile(image_path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            WidthSB.Maximum = pictureBox1.Image.Width * 2;
            WidthSB.Value = pictureBox1.Image.Width;
            textBox1.Text = pictureBox1.Image.Width.ToString();

            HeightSB.Maximum = pictureBox1.Image.Height * 2;
            HeightSB.Value = pictureBox1.Image.Height;
            textBox2.Text = pictureBox1.Image.Height.ToString();

            aspect = Convert.ToDouble(pictureBox1.Image.Width)
                / Convert.ToDouble(pictureBox1.Image.Height);
        }
        private void открытьФайлПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = ofd.OpenFile()) != null)
                {
                    StreamReader sr = new StreamReader(myStream);

                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);

                        var splittedLine = line.Split('=');
                        var value = splittedLine[1];
                  
                        Int32.TryParse(value, out int intValue);

                        if (splittedLine[0] == "Path") {
                            image_path = splittedLine[1];
                            RefreshPictureBox();
                        }
                        if (splittedLine[0] == "Width")
                        {
                            WidthSB.Value = intValue;
                            pictureBox1.Width = intValue;
                            textBox1.Text = value;
                        }
                        if (splittedLine[0] == "Height")
                        {
                            pictureBox1.Height = intValue;
                            HeightSB.Value = intValue;
                            textBox2.Text = value;
                        }
                        if (splittedLine[0] == "Left")
                        {
                            pictureBox1.Left = intValue;
                            LeftSB.Value = intValue;
                            textBox3.Text = value;
                        }
                        if (splittedLine[0] == "Top")
                        {
                            pictureBox1.Top = intValue;
                            TopSB.Value = intValue;
                            textBox4.Text = value;
                        }
                        if (splittedLine[0] == "SaveAspect")
                        {
                            checkBox1.Checked = true;
                        }
                    }
                    sr.Close();
                }
            }
        }

        private void сохранитьПараметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 0)
            {
                Stream myStream;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    if((myStream = sfd.OpenFile()) != null)
                    {
                        CreateFileWithParameters(myStream);
                            
                    }
                }
            }
            else
            {

            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WidthSB_Scroll(object sender, ScrollEventArgs e)
        {
            var value = (sender as ScrollBar).Value;
            pictureBox1.Width = value;
            if (checkBox1.Checked)
            {
                pictureBox1.Height = Convert.ToInt32(WidthSB.Value / aspect);
                HeightSB.Value = pictureBox1.Height;
                textBox2.Text = pictureBox1.Height.ToString();

            }
            textBox1.Text = value.ToString();

        }
        
        private void HeightSB_Scroll(object sender, ScrollEventArgs e)
        {
            var value = (sender as ScrollBar).Value;
            pictureBox1.Height= value;

            if (checkBox1.Checked)
            {
                pictureBox1.Width = Convert.ToInt32(HeightSB.Value * aspect);
                WidthSB.Value = pictureBox1.Width;
                textBox1.Text = pictureBox1.Width.ToString();

            }
            textBox2.Text = value.ToString();
        }

        private void LeftSB_Scroll(object sender, ScrollEventArgs e)
        {
            var value = (sender as ScrollBar).Value;
            pictureBox1.Left = value;
            textBox3.Text = value.ToString();
        }

        private void TopSB_Scroll(object sender, ScrollEventArgs e)
        {
            var value = (sender as ScrollBar).Value;
            pictureBox1.Top = value;
            textBox4.Text = value.ToString();
        }

        private void создатьФайлПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName != null)
                {
                    CreateFileWithParameters(sfd.OpenFile());
                }
            }
        }
        private void CreateFileWithParameters(Stream stream)
        {
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine($"Path={image_path}");
            sw.WriteLine($"Width={pictureBox1.Image.Width}");
            sw.WriteLine($"Height={pictureBox1.Image.Height}");
            sw.WriteLine($"Top={pictureBox1.Top}");
            sw.WriteLine($"Left={pictureBox1.Left}");
            sw.WriteLine($"SaveAspect={checkBox1.Checked}");
            //

            sw.Close();
        }
    }
}
