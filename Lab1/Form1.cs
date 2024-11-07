using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiCalculate_Click(object sender, EventArgs e)
        {
            try
            {


                DateTime BirthTime = DateTime.Parse(maskedTextBox.Text);
                TimeSpan interval = DateTime.Today - BirthTime;
                string tmp = "Дата рождения: " + BirthTime.ToShortDateString() + " / ";

                if (rbYears.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных лет: " + (interval.Days / 365).ToString());
                    return;
                }
                if (rbMonths.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных месяцев: " + (interval.Days / 31).ToString());
                    return;

                }
                if (rbDays.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных дней: " + (interval.Days).ToString());
                    return;

                }
                if (rbHours.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных часов: " + (interval.TotalHours).ToString());
                    return;

                }
                if (rbMinutes.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных минут: " + (interval.TotalMinutes).ToString());

                    return;
                }
                if (rbSeconds.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных секунд: " + (interval.TotalSeconds).ToString());
                    return;

                }
                MessageBox.Show("Выберите необходимую единицу измерения");
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Введите правильную дату");
            }
        }

        private void clearDate_Click(object sender, EventArgs e)
        {
            maskedTextBox.Clear();
        }

        private void clearRez_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа расчета прожитого времени в различных единицах измерения", "О программе", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
