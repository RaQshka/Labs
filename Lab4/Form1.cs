using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private Logger logger;
        public Form1()
        {
            InitializeComponent();
            logger = new Logger();
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
                    tmp = tmp + "Количество полных лет: " + (interval.Days / 365).ToString();
                }
                else if (rbMonths.Checked)
                {
                    tmp = tmp + "Количество полных месяцев: " + (interval.Days / 31).ToString();
                }
                else if (rbDays.Checked)
                {
                    tmp = tmp + "Количество полных дней: " + (interval.Days).ToString();
                }
                else if (rbHours.Checked)
                {
                    tmp = tmp + "Количество полных часов: " + (interval.TotalHours).ToString();
                }
                else if (rbMinutes.Checked)
                {
                    tmp = tmp + "Количество полных минут: " + (interval.TotalMinutes).ToString();
                }
                else if (rbSeconds.Checked)
                {
                    tmp = tmp + "Количество полных секунд: " + (interval.TotalSeconds).ToString();
                }
                else
                {
                    MessageBox.Show("Выберите необходимую единицу измерения");
                    logger.Log($"Пользователь ввел значения: {BirthTime.ToShortDateString()} но не ввел единицу измерения.");
                    return;
                }
                listBox.Items.Add(tmp);

                logger.Log($"Пользователь ввел значения: {BirthTime.ToShortDateString()}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите правильную дату");
            }
        }

        private void clearDate_Click(object sender, EventArgs e)
        {
            maskedTextBox.Clear();
            logger.Log();
        }

        private void clearRez_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            logger.Log();
        }

        private void aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа расчета прожитого времени в различных единицах измерения", "О программе",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            logger.Log();
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
                        logger.Log("Выделенные данные написаны в отличной от выбранной единицы измерения. ");
                        return;
                    }

                    sum += UInt64.Parse(splittedText[7]);
                }
                textBox1.Visible = true;
                textBox1.Text = $"Сумма выделенных данных: {sum} {currentMeasure}";
                logger.Log($"Сумма выделенных данных: {sum} {currentMeasure}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Выделенные данные некорректны. Очистите список и повторите попытку.");
                logger.Log("Произошла ошибка во время расчета данных. ");
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
            logger.Log($"Переключен режим суммы результатов на {(sender as CheckBox).Checked}. ");
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if(radio.Checked)
                logger.Log($"Переключен режим {radio.Text} на {radio.Checked}. ");
        }

        private void showLogsButton_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Width = 800;

            ListBox lb = new ListBox();
            lb.Dock = DockStyle.Fill;
            foreach (var item in logger.ReadLogs())
            {
                lb.Items.Add(item);
            }
            form.Controls.Add(lb);
            form.Show();
        }
    }
    public class Logger
    {
        private string _folderPath = Directory.GetCurrentDirectory() + "\\Log";
        private string _path = Directory.GetCurrentDirectory() + "\\Log\\logs.log";
        public Logger()
        {
            try
            {
                if (!Directory.Exists(_folderPath))
                {
                    Directory.CreateDirectory(_folderPath);
                }
                if (!File.Exists(_path))
                {
                    File.Create(_path).Close();
                }
            }
            catch(IOException)
            {
                MessageBox.Show("Ошибка ввода-вывода при создании лог файлов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Log(string message = "", bool addMethodInfo = true)
        {
            if (!File.Exists(_path)) return;

            var loggingString = new StringBuilder() ;
            loggingString.Append(DateTime.Now);
            loggingString.Append(' ');
            if (!string.IsNullOrEmpty(message))
            {
                loggingString.Append(message);
            }
            if (addMethodInfo)
            {
                var methodName = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;
                loggingString.Append($" (вызван метод {methodName})");
            }
            WriteLogToFile(loggingString.ToString());
        }
        private void WriteLogToFile(string message)
        {
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(message);
            }
        }
        public IEnumerable<string> ReadLogs()
        {
            List<string> logs = new List<string>();
            using (StreamReader sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    logs.Add(sr.ReadLine());
                }
            }
            return logs;
        }

    }
}
