using Lab9.dsTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                street_listTableAdapter.Update(ds.street_list);

            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Произошла ошибка при обновлении базы данных на строке " + ex.Row);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка при обновлении базы данных: " + ex.Message);
            }
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ds.street_list". При необходимости она может быть перемещена или удалена.
            this.street_listTableAdapter.Fill(this.ds.street_list);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ds.city_list". При необходимости она может быть перемещена или удалена.
            this.city_listTableAdapter.Fill(this.ds.city_list);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ds.regions_list". При необходимости она может быть перемещена или удалена.
            this.regions_listTableAdapter.Fill(this.ds.regions_list);

        }
        /*regions->city->street*/
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {

                ds.street_listDataTable streetDeleted =
                    (ds.street_listDataTable)ds.street_list.GetChanges(DataRowState.Deleted);

                if (streetDeleted != null)
                {
                    street_listTableAdapter.Update(streetDeleted);
                }

                ds.city_listDataTable cityDeleted =
                    (ds.city_listDataTable)ds.city_list.GetChanges(DataRowState.Deleted);
                ds.city_listDataTable cityAdded =
                    (ds.city_listDataTable)ds.city_list.GetChanges(DataRowState.Added);
                ds.city_listDataTable cityModified =
                    (ds.city_listDataTable)ds.city_list.GetChanges(DataRowState.Modified);

                if (cityDeleted != null)
                {
                    city_listTableAdapter.Update(cityDeleted);
                }
                if (cityAdded != null)
                {
                    city_listTableAdapter.Update(cityAdded);
                }
                if (cityModified != null)
                {
                    city_listTableAdapter.Update(cityModified);
                }

                ds.street_listDataTable streetAddedOrModified =
                    (ds.street_listDataTable)ds.street_list.GetChanges(DataRowState.Added | DataRowState.Modified);

                if (streetAddedOrModified != null)
                {
                    street_listTableAdapter.Update(streetAddedOrModified);
                }

                ds.AcceptChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка при обновлении базы данных: " + ex.Message);
            }
        }

    }
}
