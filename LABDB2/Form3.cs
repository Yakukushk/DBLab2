using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LABDB2
{
    enum RowState {
    Existed,
    New,
    Modified,
    ModifiedNew,
    Deleted
    }
    public partial class Form3 : Form
    {
        DB data = new DB();
        int RowsSelected;
        private void Form3_Load(object sender, EventArgs e)
        {
            CreateCollumn();
            RefreshDataGridView(dataGridView1);
           
            
        }
        public Form3()
        {

            InitializeComponent();
        }
       
        private void CreateCollumn() {
            
            dataGridView1.Columns.Add("id", "Id");
            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("count_id", "Count");
            dataGridView1.Columns.Add("booking", "Booking");
            dataGridView1.Columns.Add("price", "Price");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void Reader(DataGridView dataGrid, IDataRecord record) {
           
                dataGrid.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetInt32(4), RowState.ModifiedNew);
            
            }
        private void RefreshDataGridView(DataGridView dataGrid) {

            try
            {
                dataGrid.Rows.Clear();

                string str = $"select * from test_db";
                SqlCommand command = new SqlCommand(str, data.getConnection());
                data.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reader(dataGrid, reader);

                }
                reader.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_search.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowsSelected = e.RowIndex;
            if (e.RowIndex >= 0) {
                DataGridViewRow row = dataGridView1.Rows[RowsSelected];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridView1);
        }
        private void Search(DataGridView dataGridView) {
            dataGridView.Rows.Clear();
            string str = $"select * from test_db where concat (id, name, count_id, booking, price) like '%" + textBox_search.Text + "%'";
            SqlCommand command = new SqlCommand(str, data.getConnection());
            data.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Reader(dataGridView, reader);
            }
            reader.Close();
        }
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
