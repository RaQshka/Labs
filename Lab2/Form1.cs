using System;
using System.Windows.Forms;

namespace Lab2
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
                }
                else if (rbMonths.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных месяцев: " + (interval.Days / 31).ToString());
                }
                else if (rbDays.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных дней: " + (interval.Days).ToString());
                }
                else if (rbHours.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных часов: " + (interval.TotalHours).ToString());
                }
                else if (rbMinutes.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных минут: " + (interval.TotalMinutes).ToString());
                }
                else if (rbSeconds.Checked)
                {
                    listBox.Items.Add(tmp + "Количество полных секунд: " + (interval.TotalSeconds).ToString());
                }
                else
                {
                    MessageBox.Show("Выберите необходимую единицу измерения");
                }
            }
            catch (FormatException)
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

        private void sumOfCheckedButton_Click(object sender, EventArgs e)
        {
            UInt64 sum = 0;
            try
            {
                var currentMeasure = GetMeasure();
                //проверка все ли данные соответствуют выделенному типу данных
                foreach (string item in checkedListBox.CheckedItems)
                {
                    var splittedText = item.Split(' ');
                    var measure = splittedText[6].Replace(":", "");

                    if (measure != currentMeasure)
                    {
                        MessageBox.Show("Выделенные данные написаны в отличной от выбранной единицы измерения! Выберите данные одного типа.");
                        return;
                    }

                    sum += UInt64.Parse(splittedText[7]);
                }
                textBox1.Visible = true;
                textBox1.Text = $"Сумма выделенных данных: {sum} {currentMeasure}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Выделенные данные некорректны. Очистите список и повторите попытку.");
            }

        }
        private string GetMeasure()
        {
            if (rbYears.Checked)
                return "лет";

            if (rbMonths.Checked)
                return "месяцев";

            if (rbDays.Checked)
                return "дней";

            if (rbHours.Checked)
                return "часов";

            if (rbMinutes.Checked)
                return "минут";

            if (rbSeconds.Checked)
                return "секунд";

            return string.Empty;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                sumOfCheckedButton.Visible = true;
                listBox.Visible = false;
                checkedListBox.Visible = true;

                foreach (string item in listBox.Items)
                {
                    checkedListBox.Items.Add(item);
                }

                tsbCalculate.Enabled = false;
                tsmiCalculate.Enabled = false;
                maskedTextBox.Enabled = false;

            }
            else
            {
                checkedListBox.Items.Clear();
                sumOfCheckedButton.Visible = false;
                listBox.Visible = true;
                checkedListBox.Visible = false;
                textBox1.Visible = false;
                tsbCalculate.Enabled = true;
                tsmiCalculate.Enabled = true;
                maskedTextBox.Enabled = true;

            }

        }
    }
}
