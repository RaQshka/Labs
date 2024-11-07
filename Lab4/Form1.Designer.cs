namespace Lab4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.gbRez = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sumOfCheckedButton = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.gbCalculate = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rbSeconds = new System.Windows.Forms.RadioButton();
            this.rbMinutes = new System.Windows.Forms.RadioButton();
            this.rbHours = new System.Windows.Forms.RadioButton();
            this.rbDays = new System.Windows.Forms.RadioButton();
            this.rbMonths = new System.Windows.Forms.RadioButton();
            this.rbYears = new System.Windows.Forms.RadioButton();
            this.gbInputDate = new System.Windows.Forms.GroupBox();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCalculate = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDate = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRez = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCalculate = new System.Windows.Forms.ToolStripButton();
            this.tsbClearDate = new System.Windows.Forms.ToolStripButton();
            this.tsbClearResults = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.gbRez.SuspendLayout();
            this.gbCalculate.SuspendLayout();
            this.gbInputDate.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gbRez);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gbCalculate);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gbInputDate);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1067, 499);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1067, 554);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // gbRez
            // 
            this.gbRez.Controls.Add(this.listBox);
            this.gbRez.Controls.Add(this.textBox1);
            this.gbRez.Controls.Add(this.sumOfCheckedButton);
            this.gbRez.Controls.Add(this.checkedListBox);
            this.gbRez.Location = new System.Drawing.Point(279, 4);
            this.gbRez.Margin = new System.Windows.Forms.Padding(4);
            this.gbRez.Name = "gbRez";
            this.gbRez.Padding = new System.Windows.Forms.Padding(4);
            this.gbRez.Size = new System.Drawing.Size(772, 470);
            this.gbRez.TabIndex = 2;
            this.gbRez.TabStop = false;
            this.gbRez.Text = "Результаты";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(7, 33);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(758, 420);
            this.listBox.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 383);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(757, 28);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // sumOfCheckedButton
            // 
            this.sumOfCheckedButton.Location = new System.Drawing.Point(8, 417);
            this.sumOfCheckedButton.Name = "sumOfCheckedButton";
            this.sumOfCheckedButton.Size = new System.Drawing.Size(757, 41);
            this.sumOfCheckedButton.TabIndex = 2;
            this.sumOfCheckedButton.Text = "Рассчитать сумму выделенных результатов";
            this.sumOfCheckedButton.UseVisualStyleBackColor = true;
            this.sumOfCheckedButton.Visible = false;
            this.sumOfCheckedButton.Click += new System.EventHandler(this.sumOfCheckedButton_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(7, 33);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(758, 344);
            this.checkedListBox.TabIndex = 1;
            this.checkedListBox.Visible = false;
            // 
            // gbCalculate
            // 
            this.gbCalculate.Controls.Add(this.checkBox1);
            this.gbCalculate.Controls.Add(this.rbSeconds);
            this.gbCalculate.Controls.Add(this.rbMinutes);
            this.gbCalculate.Controls.Add(this.rbHours);
            this.gbCalculate.Controls.Add(this.rbDays);
            this.gbCalculate.Controls.Add(this.rbMonths);
            this.gbCalculate.Controls.Add(this.rbYears);
            this.gbCalculate.Location = new System.Drawing.Point(4, 76);
            this.gbCalculate.Margin = new System.Windows.Forms.Padding(4);
            this.gbCalculate.Name = "gbCalculate";
            this.gbCalculate.Padding = new System.Windows.Forms.Padding(4);
            this.gbCalculate.Size = new System.Drawing.Size(267, 398);
            this.gbCalculate.TabIndex = 1;
            this.gbCalculate.TabStop = false;
            this.gbCalculate.Text = "Рассчитать количество";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 356);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(205, 20);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Режим суммы результатов";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rbSeconds
            // 
            this.rbSeconds.AutoSize = true;
            this.rbSeconds.Location = new System.Drawing.Point(12, 196);
            this.rbSeconds.Margin = new System.Windows.Forms.Padding(4);
            this.rbSeconds.Name = "rbSeconds";
            this.rbSeconds.Size = new System.Drawing.Size(76, 20);
            this.rbSeconds.TabIndex = 5;
            this.rbSeconds.TabStop = true;
            this.rbSeconds.Text = "Секунд";
            this.rbSeconds.UseVisualStyleBackColor = true;
            this.rbSeconds.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbMinutes
            // 
            this.rbMinutes.AutoSize = true;
            this.rbMinutes.Location = new System.Drawing.Point(12, 165);
            this.rbMinutes.Margin = new System.Windows.Forms.Padding(4);
            this.rbMinutes.Name = "rbMinutes";
            this.rbMinutes.Size = new System.Drawing.Size(70, 20);
            this.rbMinutes.TabIndex = 4;
            this.rbMinutes.TabStop = true;
            this.rbMinutes.Text = "Минут";
            this.rbMinutes.UseVisualStyleBackColor = true;
            this.rbMinutes.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbHours
            // 
            this.rbHours.AutoSize = true;
            this.rbHours.Location = new System.Drawing.Point(12, 134);
            this.rbHours.Margin = new System.Windows.Forms.Padding(4);
            this.rbHours.Name = "rbHours";
            this.rbHours.Size = new System.Drawing.Size(68, 20);
            this.rbHours.TabIndex = 3;
            this.rbHours.TabStop = true;
            this.rbHours.Text = "Часов";
            this.rbHours.UseVisualStyleBackColor = true;
            this.rbHours.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbDays
            // 
            this.rbDays.AutoSize = true;
            this.rbDays.Location = new System.Drawing.Point(12, 103);
            this.rbDays.Margin = new System.Windows.Forms.Padding(4);
            this.rbDays.Name = "rbDays";
            this.rbDays.Size = new System.Drawing.Size(61, 20);
            this.rbDays.TabIndex = 2;
            this.rbDays.TabStop = true;
            this.rbDays.Text = "Дней";
            this.rbDays.UseVisualStyleBackColor = true;
            this.rbDays.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbMonths
            // 
            this.rbMonths.AutoSize = true;
            this.rbMonths.Location = new System.Drawing.Point(12, 73);
            this.rbMonths.Margin = new System.Windows.Forms.Padding(4);
            this.rbMonths.Name = "rbMonths";
            this.rbMonths.Size = new System.Drawing.Size(85, 20);
            this.rbMonths.TabIndex = 1;
            this.rbMonths.TabStop = true;
            this.rbMonths.Text = "Месяцев";
            this.rbMonths.UseVisualStyleBackColor = true;
            this.rbMonths.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbYears
            // 
            this.rbYears.AutoSize = true;
            this.rbYears.Location = new System.Drawing.Point(12, 42);
            this.rbYears.Margin = new System.Windows.Forms.Padding(4);
            this.rbYears.Name = "rbYears";
            this.rbYears.Size = new System.Drawing.Size(52, 20);
            this.rbYears.TabIndex = 0;
            this.rbYears.TabStop = true;
            this.rbYears.Text = "Лет";
            this.rbYears.UseVisualStyleBackColor = true;
            this.rbYears.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // gbInputDate
            // 
            this.gbInputDate.Controls.Add(this.maskedTextBox);
            this.gbInputDate.Location = new System.Drawing.Point(4, 4);
            this.gbInputDate.Margin = new System.Windows.Forms.Padding(4);
            this.gbInputDate.Name = "gbInputDate";
            this.gbInputDate.Padding = new System.Windows.Forms.Padding(4);
            this.gbInputDate.Size = new System.Drawing.Size(267, 65);
            this.gbInputDate.TabIndex = 0;
            this.gbInputDate.TabStop = false;
            this.gbInputDate.Text = "Введите дату";
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(12, 33);
            this.maskedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox.Mask = "00/00/0000";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(245, 22);
            this.maskedTextBox.TabIndex = 0;
            this.maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAction,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAction
            // 
            this.tsmiAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCalculate,
            this.clearDate,
            this.clearRez});
            this.tsmiAction.Name = "tsmiAction";
            this.tsmiAction.Size = new System.Drawing.Size(88, 24);
            this.tsmiAction.Text = "Действие";
            // 
            // tsmiCalculate
            // 
            this.tsmiCalculate.Name = "tsmiCalculate";
            this.tsmiCalculate.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiCalculate.Size = new System.Drawing.Size(238, 26);
            this.tsmiCalculate.Text = "Рассчитать";
            this.tsmiCalculate.Click += new System.EventHandler(this.tsmiCalculate_Click);
            // 
            // clearDate
            // 
            this.clearDate.Name = "clearDate";
            this.clearDate.Size = new System.Drawing.Size(238, 26);
            this.clearDate.Text = "Очистить дату";
            this.clearDate.Click += new System.EventHandler(this.clearDate_Click);
            // 
            // clearRez
            // 
            this.clearRez.Name = "clearRez";
            this.clearRez.Size = new System.Drawing.Size(238, 26);
            this.clearRez.Text = "Очистить результаты";
            this.clearRez.Click += new System.EventHandler(this.clearRez_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogsButton,
            this.оПрограммеToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 24);
            this.toolStripMenuItem1.Text = "?";
            // 
            // showLogsButton
            // 
            this.showLogsButton.Name = "showLogsButton";
            this.showLogsButton.Size = new System.Drawing.Size(230, 26);
            this.showLogsButton.Text = "Просмотреть логи...";
            this.showLogsButton.Click += new System.EventHandler(this.showLogsButton_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.aboutProgram_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCalculate,
            this.tsbClearDate,
            this.tsbClearResults});
            this.toolStrip1.Location = new System.Drawing.Point(4, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(430, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCalculate
            // 
            this.tsbCalculate.Image = ((System.Drawing.Image)(resources.GetObject("tsbCalculate.Image")));
            this.tsbCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCalculate.Name = "tsbCalculate";
            this.tsbCalculate.Size = new System.Drawing.Size(108, 24);
            this.tsbCalculate.Text = "Рассчитать";
            this.tsbCalculate.Click += new System.EventHandler(this.tsmiCalculate_Click);
            // 
            // tsbClearDate
            // 
            this.tsbClearDate.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearDate.Image")));
            this.tsbClearDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearDate.Name = "tsbClearDate";
            this.tsbClearDate.Size = new System.Drawing.Size(130, 24);
            this.tsbClearDate.Text = "Очистить дату";
            this.tsbClearDate.Click += new System.EventHandler(this.clearDate_Click);
            // 
            // tsbClearResults
            // 
            this.tsbClearResults.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearResults.Image")));
            this.tsbClearResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearResults.Name = "tsbClearResults";
            this.tsbClearResults.Size = new System.Drawing.Size(179, 24);
            this.tsbClearResults.Text = "Очистить результаты";
            this.tsbClearResults.Click += new System.EventHandler(this.clearRez_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Расчет интервала времени";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.gbRez.ResumeLayout(false);
            this.gbRez.PerformLayout();
            this.gbCalculate.ResumeLayout(false);
            this.gbCalculate.PerformLayout();
            this.gbInputDate.ResumeLayout(false);
            this.gbInputDate.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.GroupBox gbRez;
        private System.Windows.Forms.GroupBox gbCalculate;
        private System.Windows.Forms.RadioButton rbSeconds;
        private System.Windows.Forms.RadioButton rbMinutes;
        private System.Windows.Forms.RadioButton rbHours;
        private System.Windows.Forms.RadioButton rbDays;
        private System.Windows.Forms.RadioButton rbMonths;
        private System.Windows.Forms.RadioButton rbYears;
        private System.Windows.Forms.GroupBox gbInputDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAction;
        private System.Windows.Forms.ToolStripMenuItem tsmiCalculate;
        private System.Windows.Forms.ToolStripMenuItem clearDate;
        private System.Windows.Forms.ToolStripMenuItem clearRez;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbClearResults;
        private System.Windows.Forms.ToolStripButton tsbCalculate;
        private System.Windows.Forms.ToolStripButton tsbClearDate;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button sumOfCheckedButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ToolStripMenuItem showLogsButton;
    }
}

