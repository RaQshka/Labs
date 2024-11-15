using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private IEnumerable<int> ReturnNumbers(int isOdd, int divider = 2)
        {
            var num = new int[100];
            for (int i = 0; i < 100; i++)
            {
                num[i] = i;
            }
            var numQuery = num.Where(x => (x % divider) == isOdd) //14
                .Select(x=>x);


            return numQuery.ToArray();
        }
        private void четныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ReturnNumbers(0).ToList().ForEach(x=>listBox1.Items.Add(x));
        }

        private void нечетныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ReturnNumbers(0, 14).ToList().ForEach(x => listBox1.Items.Add(x));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ReturnNumbers((int)(sender as NumericUpDown).Value)
                .ToList().ForEach(x => listBox1.Items.Add(x));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new Animal()
            {
                Type = "Кот",
                Moniker = "Пушистик",
                About = new[] { "Добрый", "Мягкий", "Серый" }
            });
            arrayList.Add(new Animal()
            {
                Type = "Ёж",
                Moniker = "Колючка",
                About = new[] { "Злой", "Колючий", "Серый" }
            });
            arrayList.Add(new Animal()
            {
                Type = "Рыбка",
                Moniker = "Акуленок",
                About = new[] { "Злой", "Молчаливый", "Серый", "Кусается" }
            });
            var query1 = arrayList.ToArray().Select(x=>x as Animal)
                .Where(x => x.About.Contains("Злой"));

            query1.ToList().ForEach(x =>
                MessageBox.Show($"Это {x.Type}, а зовут его - {x.Moniker}"));

            
        }
    }
}
