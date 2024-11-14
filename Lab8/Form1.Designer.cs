namespace Lab8
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
            this.createTableButton = new System.Windows.Forms.Button();
            this.AddKeyButton = new System.Windows.Forms.Button();
            this.AddDataButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.ReadDataButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddKeyButton1 = new System.Windows.Forms.Button();
            this.ReadDataButton1 = new System.Windows.Forms.Button();
            this.createTableButton1 = new System.Windows.Forms.Button();
            this.AddDataButton1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ReadDataButton2 = new System.Windows.Forms.Button();
            this.createTableButton2 = new System.Windows.Forms.Button();
            this.AddDataButton2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // createTableButton
            // 
            this.createTableButton.Location = new System.Drawing.Point(18, 29);
            this.createTableButton.Name = "createTableButton";
            this.createTableButton.Size = new System.Drawing.Size(142, 23);
            this.createTableButton.TabIndex = 0;
            this.createTableButton.Text = "Создать таблицу";
            this.createTableButton.UseVisualStyleBackColor = true;
            this.createTableButton.Click += new System.EventHandler(this.createTableButton_Click);
            // 
            // AddKeyButton
            // 
            this.AddKeyButton.Location = new System.Drawing.Point(18, 58);
            this.AddKeyButton.Name = "AddKeyButton";
            this.AddKeyButton.Size = new System.Drawing.Size(142, 23);
            this.AddKeyButton.TabIndex = 1;
            this.AddKeyButton.Text = "Добавление ключа";
            this.AddKeyButton.UseVisualStyleBackColor = true;
            this.AddKeyButton.Click += new System.EventHandler(this.AddKeyButton_Click);
            // 
            // AddDataButton
            // 
            this.AddDataButton.Location = new System.Drawing.Point(18, 87);
            this.AddDataButton.Name = "AddDataButton";
            this.AddDataButton.Size = new System.Drawing.Size(142, 23);
            this.AddDataButton.TabIndex = 2;
            this.AddDataButton.Text = "Добавление данных";
            this.AddDataButton.UseVisualStyleBackColor = true;
            this.AddDataButton.Click += new System.EventHandler(this.AddDataButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 199);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(543, 342);
            this.listBox.TabIndex = 3;
            // 
            // ReadDataButton
            // 
            this.ReadDataButton.Location = new System.Drawing.Point(18, 116);
            this.ReadDataButton.Name = "ReadDataButton";
            this.ReadDataButton.Size = new System.Drawing.Size(142, 47);
            this.ReadDataButton.TabIndex = 4;
            this.ReadDataButton.Text = "Чтение данных таблицы";
            this.ReadDataButton.UseVisualStyleBackColor = true;
            this.ReadDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddKeyButton);
            this.groupBox1.Controls.Add(this.ReadDataButton);
            this.groupBox1.Controls.Add(this.createTableButton);
            this.groupBox1.Controls.Add(this.AddDataButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 181);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Таблица областей";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddKeyButton1);
            this.groupBox2.Controls.Add(this.ReadDataButton1);
            this.groupBox2.Controls.Add(this.createTableButton1);
            this.groupBox2.Controls.Add(this.AddDataButton1);
            this.groupBox2.Location = new System.Drawing.Point(195, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 181);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Таблица нас. пунктов";
            // 
            // AddKeyButton1
            // 
            this.AddKeyButton1.Location = new System.Drawing.Point(18, 58);
            this.AddKeyButton1.Name = "AddKeyButton1";
            this.AddKeyButton1.Size = new System.Drawing.Size(142, 23);
            this.AddKeyButton1.TabIndex = 1;
            this.AddKeyButton1.Text = "Добавление ключа";
            this.AddKeyButton1.UseVisualStyleBackColor = true;
            this.AddKeyButton1.Click += new System.EventHandler(this.AddKeyButton1_Click);
            // 
            // ReadDataButton1
            // 
            this.ReadDataButton1.Location = new System.Drawing.Point(18, 116);
            this.ReadDataButton1.Name = "ReadDataButton1";
            this.ReadDataButton1.Size = new System.Drawing.Size(142, 47);
            this.ReadDataButton1.TabIndex = 4;
            this.ReadDataButton1.Text = "Чтение данных таблицы";
            this.ReadDataButton1.UseVisualStyleBackColor = true;
            this.ReadDataButton1.Click += new System.EventHandler(this.ReadDataButton1_Click);
            // 
            // createTableButton1
            // 
            this.createTableButton1.Location = new System.Drawing.Point(18, 29);
            this.createTableButton1.Name = "createTableButton1";
            this.createTableButton1.Size = new System.Drawing.Size(142, 23);
            this.createTableButton1.TabIndex = 0;
            this.createTableButton1.Text = "Создать таблицу";
            this.createTableButton1.UseVisualStyleBackColor = true;
            this.createTableButton1.Click += new System.EventHandler(this.createTableButton1_Click);
            // 
            // AddDataButton1
            // 
            this.AddDataButton1.Location = new System.Drawing.Point(18, 87);
            this.AddDataButton1.Name = "AddDataButton1";
            this.AddDataButton1.Size = new System.Drawing.Size(142, 23);
            this.AddDataButton1.TabIndex = 2;
            this.AddDataButton1.Text = "Добавление данных";
            this.AddDataButton1.UseVisualStyleBackColor = true;
            this.AddDataButton1.Click += new System.EventHandler(this.AddDataButton1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.ReadDataButton2);
            this.groupBox3.Controls.Add(this.createTableButton2);
            this.groupBox3.Controls.Add(this.AddDataButton2);
            this.groupBox3.Location = new System.Drawing.Point(378, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(177, 181);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Таблица улиц";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавление ключа";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ReadDataButton2
            // 
            this.ReadDataButton2.Location = new System.Drawing.Point(18, 116);
            this.ReadDataButton2.Name = "ReadDataButton2";
            this.ReadDataButton2.Size = new System.Drawing.Size(142, 47);
            this.ReadDataButton2.TabIndex = 4;
            this.ReadDataButton2.Text = "Чтение данных таблицы";
            this.ReadDataButton2.UseVisualStyleBackColor = true;
            this.ReadDataButton2.Click += new System.EventHandler(this.ReadDataButton2_Click);
            // 
            // createTableButton2
            // 
            this.createTableButton2.Location = new System.Drawing.Point(18, 29);
            this.createTableButton2.Name = "createTableButton2";
            this.createTableButton2.Size = new System.Drawing.Size(142, 23);
            this.createTableButton2.TabIndex = 0;
            this.createTableButton2.Text = "Создать таблицу";
            this.createTableButton2.UseVisualStyleBackColor = true;
            this.createTableButton2.Click += new System.EventHandler(this.createTableButton2_Click);
            // 
            // AddDataButton2
            // 
            this.AddDataButton2.Location = new System.Drawing.Point(18, 87);
            this.AddDataButton2.Name = "AddDataButton2";
            this.AddDataButton2.Size = new System.Drawing.Size(142, 23);
            this.AddDataButton2.TabIndex = 2;
            this.AddDataButton2.Text = "Добавление данных";
            this.AddDataButton2.UseVisualStyleBackColor = true;
            this.AddDataButton2.Click += new System.EventHandler(this.AddDataButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 553);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createTableButton;
        private System.Windows.Forms.Button AddKeyButton;
        private System.Windows.Forms.Button AddDataButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button ReadDataButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddKeyButton1;
        private System.Windows.Forms.Button ReadDataButton1;
        private System.Windows.Forms.Button createTableButton1;
        private System.Windows.Forms.Button AddDataButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ReadDataButton2;
        private System.Windows.Forms.Button createTableButton2;
        private System.Windows.Forms.Button AddDataButton2;
    }
}

