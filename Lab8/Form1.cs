using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=RAQSHKA\SQLEXPRESS;Database=ADO.NET;Trusted_Connection=Yes;";

        public Form1()
        {
            InitializeComponent();
        }

        private void ExecuteQuery(string query)
        {

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.StateChange += new StateChangeEventHandler(Cn_StateChange);
                cn.InfoMessage += new SqlInfoMessageEventHandler(Cn_InfoMessage);
                cn.Open();

                SqlCommand command = new SqlCommand()
                {
                    Connection = cn, 
                    CommandText = query,
                };
                command.ExecuteNonQuery();
            }
        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show("Сервер говорит, что " +e.Message);
        }

        private void Cn_StateChange(object sender, StateChangeEventArgs e)
        {
            MessageBox.Show($"Состояние изменено с {e.OriginalState} на {e.CurrentState}");
        }

        private void createTableButton_Click(object sender, EventArgs e)
        {
            string sqlstrDrop = "drop table regions_list;";
            string sqlStr = "create table regions_list(region_ID int identity(1,1), region_name varchar(25));";

            try
            {
                ExecuteQuery(sqlstrDrop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении таблицы: " + ex.Message);
            }

            ExecuteQuery(sqlStr);
         
        }

        private void AddKeyButton_Click(object sender, EventArgs e)
        {
            string sqlstr = "Alter table regions_list add constraint regions_list_pk primary key(region_ID);";

            ExecuteQuery(sqlstr);

        }

        private void AddDataButton_Click(object sender, EventArgs e)
        {
            string sqlstr = @"INSERT INTO regions_list VALUES('Автономна республіка Крим');
                INSERT INTO regions_list VALUES('Вінницька');
                INSERT INTO regions_list VALUES('Волинська');
                INSERT INTO regions_list VALUES('Дніпропетровська');
                INSERT INTO regions_list VALUES('Донецька');
                INSERT INTO regions_list VALUES('Житомирська');
                INSERT INTO regions_list VALUES('Закарпатська');
                INSERT INTO regions_list VALUES('Запоріжська');
                INSERT INTO regions_list VALUES('Івано-Франківська');
                INSERT INTO regions_list VALUES('Київська');
                INSERT INTO regions_list VALUES('Кіровоградська');
                INSERT INTO regions_list VALUES('Луганська');
                INSERT INTO regions_list VALUES('Львівська');
                INSERT INTO regions_list VALUES('Миколаївська');
                INSERT INTO regions_list VALUES('Одеська');
                INSERT INTO regions_list VALUES('Полтавська');
                INSERT INTO regions_list VALUES('Рівненська');
                INSERT INTO regions_list VALUES('Сумська');
                INSERT INTO regions_list VALUES('Тернопільська');
                INSERT INTO regions_list VALUES('Харківська');
                INSERT INTO regions_list VALUES('Херсонська');
                INSERT INTO regions_list VALUES('Хмельницька');
                INSERT INTO regions_list VALUES('Черкаська');
                INSERT INTO regions_list VALUES('Чернівецька');
                INSERT INTO regions_list VALUES('Чернигівська');";
            ExecuteQuery(sqlstr);
        }
        private void FillListBoxWithData(string sqlstr, string separator = " ", params int[] outputIndexers )
        {
            listBox.Items.Clear();
            if (outputIndexers.Length == 0)
            {
                outputIndexers = new int[1] { 0 };
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.StateChange += new StateChangeEventHandler(Cn_StateChange);
                cn.InfoMessage += new SqlInfoMessageEventHandler(Cn_InfoMessage);
                cn.Open();

                SqlCommand command = new SqlCommand(sqlstr, cn);

                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    foreach(var i in outputIndexers)
                        listBox.Items.Add(rdr[i] + separator);
                }
                rdr.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var sqlstr = "SELECT region_name from regions_list";
            FillListBoxWithData(sqlstr);    

        }

        private void createTableButton1_Click(object sender, EventArgs e)
        {
            string sqlstrDrop = "drop table city_list;";
            string sqlStr = @"CREATE TABLE city_list(
                             city_id INT IDENTITY(1,1),
                             region_id INT,
                             city_name VARCHAR(100)
                            );";
         
            try
            {
                ExecuteQuery(sqlstrDrop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении таблицы: " + ex.Message);
            }

            ExecuteQuery(sqlStr);
        }

        private void AddKeyButton1_Click(object sender, EventArgs e)
        {
            var query = @"ALTER TABLE city_list ADD CONSTRAINT city_list_pk PRIMARY KEY(city_ID);
                        ALTER TABLE city_list ADD CONSTRAINT city_name_uniq UNIQUE(city_name);
                        ALTER TABLE city_list ADD CONSTRAINT region_city FOREIGN KEY (region_id)
                        REFERENCES regions_list (region_id);";
            ExecuteQuery(query);
        }

        private void AddDataButton1_Click(object sender, EventArgs e)
        {
            var query = @"INSERT INTO city_list VALUES(12,'м. Луганськ');
                        INSERT INTO city_list VALUES(12,'м. Свердловськ');
                        INSERT INTO city_list VALUES(12,'смт. Станично-Луганське');
                        INSERT INTO city_list VALUES(10,'м. Київ');
                        INSERT INTO city_list VALUES(10,'м. Бровари');
                        INSERT INTO city_list VALUES(5,'м. Донецьк');
                        INSERT INTO city_list VALUES(10,'м. Вишгород');
                        INSERT INTO city_list VALUES(6,'м. Житомир');
                        INSERT INTO city_list VALUES(12,'Меловський район, смт Мелове');
                        INSERT INTO city_list VALUES(4,'м. Дніпропетровськ');
                        INSERT INTO city_list VALUES(12,'м. Ровеньки');
                        INSERT INTO city_list VALUES(23,'м. Черкаси');
                        INSERT INTO city_list VALUES(12,'м. Алчевськ');
                        INSERT INTO city_list VALUES(12,'Перевальський р-н, с. Лиман');
                        INSERT INTO city_list VALUES(5,'Макеєвка. Центральний міський район');
                        INSERT INTO city_list VALUES(12,'Станично-Луганський район, с.Колесніковка');
                        INSERT INTO city_list VALUES(12,'Перевальський р-н, пос. Чорнухіно');";
            ExecuteQuery(query);

        }

        private void ReadDataButton1_Click(object sender, EventArgs e)
        {
            var sqlstr = "SELECT city_name from city_list";
            FillListBoxWithData(sqlstr);
        }

        private void createTableButton2_Click(object sender, EventArgs e)
        {
            string sqlstrDrop = "drop table street_list;";
            string sqlStr = @"CREATE TABLE street_list(
                             street_id INT IDENTITY(1,1),
                             city_id INT,
                             street_name VARCHAR(80));";
            try
            {
                ExecuteQuery(sqlstrDrop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении таблицы: " + ex.Message);
            }

            ExecuteQuery(sqlStr);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = @"ALTER TABLE street_list ADD CONSTRAINT street_list_pk PRIMARY
                            KEY(street_id);
                            ALTER TABLE street_list ADD CONSTRAINT street_city FOREIGN
                            KEY(city_id) REFERENCES city_list (city_id);
                            ALTER TABLE street_list ADD CONSTRAINT street_city_uniq UNIQUE (city_id,
                            street_name);";
            ExecuteQuery(query);
        }

        private void AddDataButton2_Click(object sender, EventArgs e)
        {
            var query = @"INSERT INTO street_list VALUES(1,'16 лінія вул. ');
                        INSERT INTO street_list VALUES(4,'Красноармейська вул.');
                        INSERT INTO street_list VALUES(2,'Красноармейська вул. ');
                        INSERT INTO street_list VALUES(3,'Чапаєва вул.');
                        INSERT INTO street_list VALUES(1,'Гражданськая вул.');
                        INSERT INTO street_list VALUES(1,'Дьоміна вул.');
                        INSERT INTO street_list VALUES(4,'Червонозоряний просп.');
                        INSERT INTO street_list VALUES(1,'Коцюбинського вул.');
                        INSERT INTO street_list VALUES(1,'Сент_Етьєновськая вул.');
                        INSERT INTO street_list VALUES(1,'Совєтская вул.');
                        INSERT INTO street_list VALUES(1,'Славянская вул.');
                        INSERT INTO street_list VALUES(1,'К. Маркса вул.');
                        INSERT INTO street_list VALUES(4,'Пушкинськая вул.');
                        INSERT INTO street_list VALUES(1,'4 Донецькая вул.');
                        INSERT INTO street_list VALUES(1,'Лутугінская вул.');
                        INSERT INTO street_list VALUES(1,'Лермонтова вул.');
                        INSERT INTO street_list VALUES(1,'Магнітогорськая вул.');
                        INSERT INTO street_list VALUES(5,'Незалежності вул.');
                        INSERT INTO street_list VALUES(4,'Горького вул.');
                        INSERT INTO street_list VALUES(1,'Димитрова кв.');
                        INSERT INTO street_list VALUES(6,'Миру просп.');
                        INSERT INTO street_list VALUES(4,'Артема вул.');
                        INSERT INTO street_list VALUES(6,'50-річчя СРСР вул.');
                        INSERT INTO street_list VALUES(1,'Пролєтаріата Донбасу кв.');
                        INSERT INTO street_list VALUES(1,'Оборонная вул.');
                        INSERT INTO street_list VALUES(1,'Полтавський пров.');
                        INSERT INTO street_list VALUES(7,'Шевченко просп.');
                        INSERT INTO street_list VALUES(8,'Ватутіна вул.');
                        INSERT INTO street_list VALUES(1,'Волкова кв.');
                        INSERT INTO street_list VALUES(1,'Ленінського комсомолу кв.');
                        INSERT INTO street_list VALUES(1,'Сосюри вул.');
                        INSERT INTO street_list VALUES(1,'Володарського вул.');
                        INSERT INTO street_list VALUES(1,'Гаєвого кв.');
                        INSERT INTO street_list VALUES(1,'Свердлова вул.');
                        INSERT INTO street_list VALUES(1,'Нахімова вул.');
                        INSERT INTO street_list VALUES(1,'Станкостроітєльная вул.');
                        INSERT INTO street_list VALUES(4,'Т. Шевченко бульвар');
                        INSERT INTO street_list VALUES(1,'Моторний просп.');
                        INSERT INTO street_list VALUES(1,'Заводськой просп.');
                        INSERT INTO street_list VALUES(4,'Кловський спуск');
                        INSERT INTO street_list VALUES(1,'Фрунзе вул.');
                        INSERT INTO street_list VALUES(1,'Челюскінців вул.');
                        INSERT INTO street_list VALUES(1,'Демьохіна вул.');
                        INSERT INTO street_list VALUES(1,'Червона пл.');
                        INSERT INTO street_list VALUES(10,'Дзержинського вул.');
                        INSERT INTO street_list VALUES(1,'2 Славянская вул.');
                        INSERT INTO street_list VALUES(1,'Корольова вул.');
                        INSERT INTO street_list VALUES(1,'Солнєчний кв.');
                        INSERT INTO street_list VALUES(1,'Леніна вул.');
                        INSERT INTO street_list VALUES(1,'Кримская вул.');
                        INSERT INTO street_list VALUES(4,'Госпітальная вул.');
                        INSERT INTO street_list VALUES(11,'Єсеніна вул.');
                        INSERT INTO street_list VALUES(1,'Будьонного вул.');
                        INSERT INTO street_list VALUES(1,'2 Свердлова вул.');
                        INSERT INTO street_list VALUES(1,'Тітова вул.');
                        INSERT INTO street_list VALUES(1,'Звейнека вул.');
                        INSERT INTO street_list VALUES(1,'7 Лутугінський проїзд вул.');
                        INSERT INTO street_list VALUES(1,'Артьома вул.');
                        INSERT INTO street_list VALUES(1,'Краснодонський пров.');
                        INSERT INTO street_list VALUES(1,'Героїв ВОВ пл.');
                        INSERT INTO street_list VALUES(1,'Херсонская вул.');
                        INSERT INTO street_list VALUES(1,'Гагаріна кв.');
                        INSERT INTO street_list VALUES(1,'Кропівницького вул.');
                        INSERT INTO street_list VALUES(1,'Красногорський пров.');
                        INSERT INTO street_list VALUES(1,'2 Краснознамьонная вул.');
                        INSERT INTO street_list VALUES(1,'Фабрічная вул.');
                        INSERT INTO street_list VALUES(4,'П. Усенко вул.');
                        INSERT INTO street_list VALUES(1,'Ліньова вул.');
                        INSERT INTO street_list VALUES(1,'1 Балтийський пров.');
                        INSERT INTO street_list VALUES(1,'Апрєльская вул.');
                        INSERT INTO street_list VALUES(4,'Кіквідзе вул.');
                        INSERT INTO street_list VALUES(4,'Павловская вул.');
                        INSERT INTO street_list VALUES(1,'23 лінія вул.');
                        INSERT INTO street_list VALUES(4,'Станкостроітєльная вул.');
                        INSERT INTO street_list VALUES(1,'Совхозная вул.');
                        INSERT INTO street_list VALUES(1,'Свєтлая вул.');
                        INSERT INTO street_list VALUES(1,'15 лінія вул.');
                        INSERT INTO street_list VALUES(12,'Смілянская вул.');
                        INSERT INTO street_list VALUES(1,'Газети Луганської правди вул.');
                        INSERT INTO street_list VALUES(13,'Гмирі вул.');
                        INSERT INTO street_list VALUES(1,'3 Донєцкая вул.');
                        INSERT INTO street_list VALUES(1,'Кольцова вул.');
                        INSERT INTO street_list VALUES(1,'Шевченко кв.');
                        INSERT INTO street_list VALUES(1,'Ватутіна вул.');
                        INSERT INTO street_list VALUES(1,'Градусова вул.');
                        INSERT INTO street_list VALUES(15,'Донєцкая вул.');
                        INSERT INTO street_list VALUES(1,'Ольховський кв.');
                        INSERT INTO street_list VALUES(1,'Комарова кв.');
                        INSERT INTO street_list VALUES(16,'Песчаная вул.');
                        INSERT INTO street_list VALUES(1,'Єрьоменко кв.');
                        INSERT INTO street_list VALUES(1,'Героїв Сталінграда кв.');
                        INSERT INTO street_list VALUES(1,'Мірний кв.');
                        INSERT INTO street_list VALUES(6,'Моцарта вул.');
                        INSERT INTO street_list VALUES(17,'Центральная вул.');
                        INSERT INTO street_list VALUES(4,'Сокольская вул.');
                        INSERT INTO street_list VALUES(1,'Жукова кв.');
                        INSERT INTO street_list VALUES(1,'60-річчя образованія СРСР кв.');
                        INSERT INTO street_list VALUES(1,'Возрождєнія вул.');
                        INSERT INTO street_list VALUES(1,'Тімірязєва вул.');";
            ExecuteQuery(query);
        }

        private void ReadDataButton2_Click(object sender, EventArgs e)
        {
            var sqlstr = "SELECT street_name from street_list";
            FillListBoxWithData(sqlstr);
        }
    }
}
