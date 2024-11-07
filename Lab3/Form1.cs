using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateDirLog();
            CreateFile();
            WriteLogFile("конструктор формы");
        }

        private void toolSBLoadInfo_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            listBox.Items.Add("Использование System.IO.Directory");
            listBox.Items.Add(System.IO.Directory.GetCurrentDirectory());
            listBox.Items.Add(System.IO.Directory.GetCreationTime("."));
            listBox.Items.Add(System.IO.Directory.GetParent("."));
            //организация работы с DirectoryInfo
            listBox.Items.Add("Использование System.IO.DirectoryInfo");
            System.IO.DirectoryInfo d_inf =
            new System.IO.DirectoryInfo(".");
            listBox.Items.Add(d_inf.Name);
            listBox.Items.Add(d_inf.Parent);
            listBox.Items.Add(d_inf.CreationTime);
            WriteLogFile("Обработчик кнопки Загрузить");
            ReadLog();

        }
        private void CreateDirLog()
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Log");
            WriteLogFile("Вызов метода CreateDirLog");
        }
        private void CreateFile()
        {
            var fs = File.Create(Directory.GetCurrentDirectory() + "\\Log\\empty.log");
            fs.Close();
            WriteLogFile("Вызов метода CreateFile");
        }
        private void WriteLogFile(string actionUser)
        {
            string path = Directory.GetCurrentDirectory() + "\\Log\\empty.log";

            FileStream fs = new FileStream(path, FileMode.Append);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToLocalTime() + " - " + actionUser);
            sw.Close();
            fs.Close();
        }

        private void ReadLog()
        {
            string path = Directory.GetCurrentDirectory() + "\\Log\\empty.log";
            string input;
            if(File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while((input = sr.ReadLine()) != null)
                    {
                        listBox.Items.Add(input);
                    }
                }
            }
            WriteLogFile("Вызов метода ReadLog");
        }


    }
}
