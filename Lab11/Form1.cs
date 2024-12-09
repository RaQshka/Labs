using Lab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

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
            foreach (var region in query)
            {
                listBox3.Items.Add(region.region_name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            LinqMyDbDataContext context = new LinqMyDbDataContext();
            var query = context.regions_list.Where(x => x.region_name.StartsWith((sender as TextBox).Text));
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
                listBox4.Items.Clear();
                foreach (var item in db.BusStations)
                {
                    listBox4.Items.Add($"Название станции: {item.Name}, г.{item.Location}");
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load("../../region.xml");
            var query = xdoc.Descendants("region_name").Select(x => x.Value);

            listBox6.Items.Clear();
            foreach (var item in query)
            {
                listBox6.Items.Add(item);
            }

            LinqMyDbDataContext ldb = new LinqMyDbDataContext();
            XElement xElement = new XElement("city_list",
                ldb.city_list.Select(x =>
                new XElement("city",
                    new XElement("city_id", x.city_id),
                    new XElement("region_id", x.region_id),
                    new XElement("city_name", x.city_name)
                )
                ));
            xElement.Save("../../city_list.xml");

            XDocument xdocc = XDocument.Load("../../city_list.xml");

            query = xdocc.Descendants("region").Where(x =>
                    x.Element("region_name").Value.Contains("Луга")
                )
                .Select(x => x.Element("region_id").Value);

            //wtf??
            string rgnid = "";

            foreach (var s in query)
            {
                rgnid = s;
            }

            xElement = new XElement("city",
                new XElement("city_id", "18"),
                new XElement("region_id", rgnid),
                new XElement("city_name", "м. Щастя")
                );
            xdocc.Root.Add(xElement);

            string xest = "<city><city_id>18</city_id><city_name>м. Щастя</city_name></city>";

            XmlDocument document = new XmlDocument();
            document.Load("../../region.xml");
            XPathNavigator nav = document.CreateNavigator();
            nav.MoveToChild("regions", String.Empty);
            nav.MoveToChild("region", String.Empty);
            nav.MoveToChild("region_id", String.Empty);
            recursiveSearching(xest, nav);
            document.Save("../../region_happy.xml");

            var queryFull = xdocc.Descendants("city")
                .Where(x => x.Element("region_id").Value.Equals(rgnid))
                .Select(x => new
                {
                    city_id = x.Element("city_id").Value,
                    city_name = x.Element("city_name").Value
                });

            foreach (var s in queryFull)
            {
                listBox5.Items.Add(s.city_name);
            }


        }

        private void recursiveSearching(string xest, XPathNavigator nav)
        {
            if (nav.Value == "12")
            {
                nav.MoveToNext("region_name", String.Empty);
                nav.InsertAfter(xest);
            }
            else
            {
                nav.MoveToParent();
                nav.MoveToNext();
                nav.MoveToChild("region_id", String.Empty);
                recursiveSearching(xest, nav);
            }
        }

        private void mergeCityregionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XDocument regionsDoc = XDocument.Load("../../region.xml");
            XDocument citiesDoc = XDocument.Load("../../city_list.xml");


            XElement merged = new XElement("regions",
                regionsDoc.Descendants("region").Select(region =>
                {
                    string regionId = region.Element("region_ID").Value;
                    string regionName = region.Element("region_name").Value;


                    var cities = citiesDoc.Descendants("city")
                        .Where(city => city.Element("region_id").Value == regionId)
                        .Select(city => new XElement("city",
                            new XElement("city_id", city.Element("city_id").Value),
                            new XElement("city_name", city.Element("city_name").Value)
                        ));

                    return new XElement("region",
                        new XElement("region_ID", regionId),
                        new XElement("region_name", regionName),
                        new XElement("cities", cities)
                    );
                })
            );

            merged.Save("../../merged_city_region.xml");

            MessageBox.Show("XML сохранён как merged_city_region.xml");
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (listBox6.SelectedItem != null)
                {
                    string selectedRegion = listBox6.SelectedItem.ToString();

                    XDocument regionsDoc = XDocument.Load("../../region.xml");
                    string regionId = regionsDoc.Descendants("region")
                        .Where(region => region.Element("region_name").Value == selectedRegion)
                        .Select(region => region.Element("region_id").Value)
                        .FirstOrDefault();

                    if (regionId != null)
                    {
                        XDocument citiesDoc = XDocument.Load("../../city_list.xml");
                        var cities = citiesDoc.Descendants("city")
                            .Where(city => city.Element("region_id").Value == regionId)
                            .Select(city => city.Element("city_name").Value);

                        listBox5.Items.Clear();
                        foreach (var city in cities)
                        {
                            listBox5.Items.Add(city);
                        }
                    }
                }
            }
        }

        private void AddCityButton_Click(object sender, EventArgs e)
        {
            if (listBox6.SelectedItem != null)
            {
                string selectedRegion = listBox6.SelectedItem.ToString();

                XDocument regionsDoc = XDocument.Load("../../region.xml");
                string regionId = regionsDoc.Descendants("region")
                    .Where(region => region.Element("region_name").Value == selectedRegion)
                    .Select(region => region.Element("region_id").Value)
                    .FirstOrDefault();

                if (regionId != null)
                {
                    string newCityName = Microsoft.VisualBasic.Interaction.InputBox(
                        "Введите название нового города:", "Добавление города", "");

                    if (!string.IsNullOrEmpty(newCityName))
                    {
                        XDocument citiesDoc = XDocument.Load("../../city_list.xml");

                        int newCityId = citiesDoc.Descendants("city")
                            .Select(city => int.Parse(city.Element("city_id").Value))
                            .DefaultIfEmpty(0)
                            .Max() + 1;

                        XElement newCity = new XElement("city",
                            new XElement("city_id", newCityId),
                            new XElement("region_id", regionId),
                            new XElement("city_name", newCityName)
                        );

                        citiesDoc.Root.Add(newCity);

                        citiesDoc.Save("../../city_list.xml");

                        listBox5.Items.Add(newCityName);
                        MessageBox.Show("Город добавлен.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите область.");
            }
        }

        private void EditCityButton_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem != null)
            {
                string oldCityName = listBox5.SelectedItem.ToString();

                string newCityName = Microsoft.VisualBasic.Interaction.InputBox(
                    "Введите новое название города:", "Редактирование города", oldCityName);

                if (!string.IsNullOrEmpty(newCityName))
                {
                    XDocument citiesDoc = XDocument.Load("../../city_list.xml");

                    var city = citiesDoc.Descendants("city")
                        .FirstOrDefault(c => c.Element("city_name").Value == oldCityName);

                    if (city != null)
                    {
                        city.Element("city_name").Value = newCityName;

                        citiesDoc.Save("../../city_list.xml");

                        int index = listBox5.SelectedIndex;
                        listBox5.Items[index] = newCityName;

                        MessageBox.Show("Город отредактирован.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите город.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem != null)
            {
                string cityName = listBox5.SelectedItem.ToString();

                XDocument citiesDoc = XDocument.Load("../../city_list.xml");

                var city = citiesDoc.Descendants("city")
                    .FirstOrDefault(c => c.Element("city_name").Value == cityName);

                if (city != null)
                {
                    city.Remove();

                    citiesDoc.Save("../../city_list.xml");

                    listBox5.Items.Remove(cityName);
                    MessageBox.Show("Город удалён.");
                }
            }
            else
            {
                MessageBox.Show("Выберите город.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                AddCityButton.Visible = true;
                EditCityButton.Visible = true;
                RemoveCityButton.Visible = true;
            }
            else
            {
                AddCityButton.Visible = false;
                EditCityButton.Visible = false;
                RemoveCityButton.Visible = false;
            }
        }

    }
}
