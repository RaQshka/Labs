using Lab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11
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
            var query1 = arrayList.OfType<Animal>();
            if (comboBox1.Text == "Имени")
            {
                query1 = query1.Where(x => x.Type.ToLower() == searchTB.Text.ToLower());
            }
            else if (comboBox1.Text == "Кличке")
            {
                query1 = query1.Where(x => x.Moniker.ToLower() == searchTB.Text.ToLower());
            }
            else if (comboBox1.Text == "Характеристике")
            {
                query1 = query1.Where(x => x.About[(int)ArrayNumberUD.Value].ToLower() == searchTB.Text.ToLower());
            }
            else
            {
                MessageBox.Show("Неверный параметр.");
                return;
            }
            query1.ToList().ForEach(x =>
                listBox2.Items.Add($"Это {x.Type}, а зовут его - {x.Moniker}"));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 5)
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
                new Station(){
                    Name= "Central",
                    Address= "Lenina St, 1",
                    Buses =  new int[] { 1, 2, 3 }
                },
                new Station(){
                    Name="North",
                    Address="Pobedy St, 10",
                    Buses = new int[] { 4, 5, 6 }
                },
                new Station(){
                    Name="South",
                    Address="Mira St, 20",
                    Buses =new int[] { 7, 8, 9 }
                }
            };

            var query1 = busStations.OfType<Station>();
            if (comboBox1.Text == "Названию")
            {
                query1 = query1.Where(x => x.Name.ToLower() == searchTB.Text.ToLower());
            }
            else if (comboBox1.Text == "Адресу")
            {
                query1 = query1.Where(x => x.Address.ToLower() == searchTB.Text.ToLower());
            }
            else if (comboBox1.Text == "Автобусам")
            {
                query1 = query1.Where(x => x.Buses[(int)ArrayNumberUD.Value] == int.Parse(searchTB.Text));
            }
            else
            {
                MessageBox.Show("Неверный параметр.");
                return;
            }
            query1.ToList().ForEach(x =>
                listBox2.Items.Add($"Название: {x.Name}, адрес - {x.Address}"));

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            LinqMyDbDataContext context = new LinqMyDbDataContext();
            var query = context.regions_list;
            foreach(var region in query )
            {
                listBox3.Items.Add(region.region_name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            LinqMyDbDataContext context = new LinqMyDbDataContext();
            var query = context.regions_list.Where(x=>x.region_name.StartsWith((sender as TextBox).Text));
            foreach (var region in query)
            {
                listBox3.Items.Add(region.region_name);
            }
        }

        private void создатьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDataContext())
            {
                if (!db.DatabaseExists())
                {
                    db.CreateDatabase();
                    MessageBox.Show("База данных создана!");
                }
                else
                {
                    MessageBox.Show("База данных уже существует!");
                }
            }

        }

        private void добавитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDataContext())
            {
                if (!db.DatabaseExists())
                {
                    MessageBox.Show("База данных не существует!");
                    return;
                }

                // Добавляем автостанции
                var station1 = new BusStation { Name = "Центральная", Location = "Москва" };
                var station2 = new BusStation { Name = "Южная", Location = "Тула" };
                var station3 = new BusStation { Name = "Северная", Location = "Сергиев Посад" };

                db.BusStations.InsertOnSubmit(station1);
                db.BusStations.InsertOnSubmit(station2);
                db.BusStations.InsertOnSubmit(station3);
                db.SubmitChanges();

                // Добавляем маршруты
                var route1 = new Route { RouteName = "Москва - Тула", OriginStationID = station1.BusStationID, DestinationStationID = station2.BusStationID };
                var route2 = new Route { RouteName = "Москва - Сергиев Посад", OriginStationID = station1.BusStationID, DestinationStationID = station3.BusStationID };

                db.Routes.InsertOnSubmit(route1);
                db.Routes.InsertOnSubmit(route2);
                db.SubmitChanges();

                // Добавляем автобусы
                var bus1 = new Bus { BusNumber = "A100", RouteID = route1.RouteID };
                var bus2 = new Bus { BusNumber = "A200", RouteID = route2.RouteID };

                db.Buses.InsertOnSubmit(bus1);
                db.Buses.InsertOnSubmit(bus2);
                db.SubmitChanges();

                MessageBox.Show("Данные успешно добавлены!");
                listBox3.Items.Clear();
                foreach (var item in db.BusStations)
                {
                    listBox3.Items.Add($"Название станции: {item.Name}, г.{item.Location}");
                }
            }
        }

        private void удалитьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDataContext())
            {
                if (db.DatabaseExists())
                {
                    db.DeleteDatabase();
                    MessageBox.Show("База данных удалена!");
                }
                else
                {
                    MessageBox.Show("База данных не существует!");
                }
            }
        }
    }
}
