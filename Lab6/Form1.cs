using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using uno.util;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.uno;


namespace Lab6
{
    public partial class Form1 : Form
    {
        XDispatchHelper xDispatchHelperm;
        XFrame framem;
        public Form1()
        {
            InitializeComponent();
            InitOO3Env();

            if (!isOOoInstalled())
            {
                MessageBox.Show("OOo is NOT installed");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                InitOO3Env();
                MessageBox.Show("Инициализация прошла успешно!");
            }
            catch
            {
                MessageBox.Show("Инициализация прошла неудачно!");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir1 = new DirectoryInfo(".");
            string path = dir1.FullName + "\\sample\\Примерчик.оdt";
            XComponentContext localContext = Bootstrap.bootstrap();

            XMultiServiceFactory multiServiceFactory =
                (XMultiServiceFactory)localContext.getServiceManager();
            XComponentLoader componentLoader =
                (XComponentLoader)multiServiceFactory.createInstance("com.sun.star.frame.Desktop");

            XComponent xComponent = OOo3_initWriterDocument(path, true);

            //установка позиции в конец документа
            XTextRange Xrange = ((XTextDocument)xComponent).getText().getEnd();
            // вставка строки
            ((XTextDocument)xComponent).getText().insertString(Xrange, textBox1.Text, false);

            XDispatchHelper xDispatchHelper = (XDispatchHelper)multiServiceFactory.createInstance(
                "com.sun.star.frame.DispatchHelper");
            XFrame frame = ((XTextDocument)xComponent).getCurrentController().getFrame();


            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertPara", "", 0,
                new PropertyValue[0]);

            XController currController = ((XModel)xComponent).getCurrentController();
            XTextViewCursor xViewCursor =
                ((XTextViewCursorSupplier)currController).getViewCursor();
            XPropertySet xCursorProps = (XPropertySet)xViewCursor;
            xCursorProps.setPropertyValue("CharColor", new uno.Any(16711680));


            // формируем настройки цветной строки 
            PropertyValue[] colorText = new PropertyValue[1];
            colorText[0] = new PropertyValue();
            colorText[0].Name = "Text";
            colorText[0].Value = new uno.Any(textBox2.Text);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText", "", 0, colorText);
            xCursorProps = (XPropertySet)xViewCursor;
            xCursorProps.setPropertyValue("CharColor", new uno.Any(0));


            PropertyValue[] tableArgs = new PropertyValue[4];
            tableArgs[0] = new PropertyValue();
            tableArgs[1] = new PropertyValue();
            tableArgs[2] = new PropertyValue();
            tableArgs[3] = new PropertyValue();

            tableArgs[0].Name = "TableName";
            tableArgs[0].Value = new uno.Any("MyTable");
            tableArgs[1].Name = "Columns";
            tableArgs[1].Value = new uno.Any((int)numericUpDown2.Value);
            tableArgs[2].Name = "Rows";
            tableArgs[2].Value = new uno.Any((int)numericUpDown1.Value);
            tableArgs[3].Name = "Flags";
            tableArgs[3].Value = new uno.Any(9);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame,
                ".uno:InsertTable", "", 0, tableArgs);

            PropertyValue[] cellTextArgs = new PropertyValue[1];
            cellTextArgs[0] = new PropertyValue();
            cellTextArgs[0].Name = "Text";
            cellTextArgs[0].Value = new uno.Any(textBox3.Text);

            xViewCursor = ((XTextViewCursorSupplier)currController).getViewCursor();
            xViewCursor.goRight((short)(numericUpDown2.Value - 1), true);
            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:MergeCells",
                "", 0, new PropertyValue[0]);

            xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText",
                "", 0, cellTextArgs);

            for (int i = 0; i < (numericUpDown1.Value - 1) * numericUpDown2.Value; i++)
            {
                xViewCursor = ((XTextViewCursorSupplier)currController).getViewCursor();
                xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:JumpToNextCell",
                        "", 0, new PropertyValue[0]);
                xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertText",
                    "", 0, cellTextArgs);
            }

            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                Xrange = ((XTextDocument)xComponent).getText().getEnd();
                xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:GoRight", "", 0, new PropertyValue[0]);

                PropertyValue[] tableArgs1 = new PropertyValue[4];
                for (int i = 0; i < 4; i++) tableArgs1[i] = new PropertyValue();

                tableArgs1[0].Name = "FileName";
                tableArgs1[0].Value = new uno.Any(@"file:///" + textBox4.Text.Replace(@"\", @"/"));
                tableArgs1[1].Name = "FilterName";
                tableArgs1[1].Value = new uno.Any("<All formats>");
                tableArgs1[2].Name = "AsLink";
                tableArgs1[2].Value = new uno.Any(false);
                tableArgs1[3].Name = "Style";
                tableArgs1[3].Value = new uno.Any("Graphics");

                xDispatchHelper.executeDispatch((XDispatchProvider)frame, ".uno:InsertGraphic", "", 0, tableArgs1);
            }
            xDispatchHelperm = xDispatchHelper;
            framem = frame;
        }



        private void InitOO3Env()
        {
            string baseKey = "";

            if (Marshal.SizeOf(typeof(IntPtr)) == 8) baseKey = @"SOFTWARE\Wow6432Node\OpenOffice.org\";
            else
                baseKey = @"SOFTWARE\OpenOffice.org\";

            // Get the URE directory
            string key = baseKey + @"Layers\URE\1";
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(key);
            if (reg == null) reg = Registry.LocalMachine.OpenSubKey(key);
            string urePath = reg.GetValue("UREINSTALLLOCATION") as string;
            reg.Close();
            urePath = Path.Combine(urePath, "bin");

            // Get the UNO Path

            key = baseKey + @"UNO\InstallPath";
            reg = Registry.CurrentUser.OpenSubKey(key);
            if (reg == null) reg = Registry.LocalMachine.OpenSubKey(key);
            string unoPath = reg.GetValue(null) as string;
            reg.Close();

            string path;

            string sysPath = System.Environment.GetEnvironmentVariable("PATH");

            path = string.Format("{0};{1}", System.Environment.GetEnvironmentVariable("PATH"), urePath);
            System.Environment.SetEnvironmentVariable("PATH", path);
            System.Environment.SetEnvironmentVariable("UNO_PATH", unoPath);
        }

        private bool isOOoInstalled()
        {
            string baseKey;
            // Для 64 битной версии

            if (Marshal.SizeOf(typeof(IntPtr)) == 8) baseKey = @"SOFTWARE\Wow6432Node\OpenOffice.org\";
            else
                baseKey = @"SOFTWARE\OpenOffice.org\";

            string key = baseKey + @"Layers\URE\1";
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(key);
            if (reg == null) reg = Registry.LocalMachine.OpenSubKey(key);
            string urePath = reg.GetValue("UREINSTALLLOCATION") as string;
            reg.Close();
            if (urePath != null) return true;
            else
                return false;
        }

        private XMultiServiceFactory uno_connect()
        {
            XComponentContext m_xContext = Bootstrap.bootstrap();
            if (m_xContext != null)
            {
                return (XMultiServiceFactory)m_xContext.getServiceManager();
            }
            else { return null; }
        }

        private XTextDocument OOo3_initWriterDocument(string filePath, bool newDoc)
        {
            XComponentLoader aLoader;
            XComponent xComponent = null;
            string url = newDoc ? "private:factory/swriter" : @"file:///" + filePath.Replace(@"\", @"/");

            try
            {
                XMultiServiceFactory mxMSFactory = uno_connect();
                aLoader = (XComponentLoader)mxMSFactory.createInstance("com.sun.star.frame.Desktop");
                xComponent = aLoader.loadComponentFromURL(url, "_blank", 0, new PropertyValue[0]);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return (XTextDocument)xComponent;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.OpenFile() != null)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                    textBox4.Text =openFileDialog.FileName;
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            xDispatchHelperm.executeDispatch((XDispatchProvider)framem, ".uno:AlignRight", "", 0, new PropertyValue[0]);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            xDispatchHelperm.executeDispatch((XDispatchProvider)framem, ".uno:AlignCenter", "", 0, new PropertyValue[0]);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            xDispatchHelperm.executeDispatch((XDispatchProvider)framem, ".uno:AlignLeft", "", 0, new PropertyValue[0]);

        }
    }
}
