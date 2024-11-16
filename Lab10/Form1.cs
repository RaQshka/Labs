using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                .Select(x => x);


            return numQuery.ToArray();
        }
        private void четныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ReturnNumbers(0).ToList().ForEach(x => listBox1.Items.Add(x));
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
            listBox2.Items.Clear();
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
            var query1 = arrayList.ToArray().Select(x => x as Animal);
            if (comboBox1.Text == "Имени")
            {
                query1 = query1.Where(x => x.Type == searchTB.Text);
            }
            else if (comboBox1.Text == "Кличке")
            {
                query1 = query1.Where(x => x.Moniker == searchTB.Text);
            }
            else if (comboBox1.Text == "Характеристике")
            {
                query1 = query1.Where(x => x.About[(int)ArrayNumberUD.Value] == searchTB.Text);
            }
            else
            {
                MessageBox.Show("Неверный параметр.");
            }
            query1.ToList().ForEach(x =>
                listBox2.Items.Add($"Это {x.Type}, а зовут его - {x.Moniker}"));

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 2|| comboBox1.SelectedIndex ==5)
            {
                label3.Visible = true;
                ArrayNumberUD.Visible = true;
            }
            else
            {
                label3.Visible = false;
                ArrayNumberUD.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            ArrayList busStations = new ArrayList {
                new BusStation(){
                    Name= "Central",
                    Address= "Lenina St, 1",
                    Buses =  new int[] { 1, 2, 3 }
                },
                new BusStation(){
                    Name="North", 
                    Address="Pobedy St, 10",
                    Buses = new int[] { 4, 5, 6 } 
                },
                new BusStation(){
                    Name="South", 
                    Address="Mira St, 20", 
                    Buses =new int[] { 7, 8, 9 } 
                } 
            };
            
            var result1 = busStations.OfType<BusStation>()
                .Where(b => b.Buses.Contains(5)).ToList();

            //listBox2.Items.Add();

        }
    }
}
