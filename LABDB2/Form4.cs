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
    public partial class Form4 : Form
    {
        DB data = new DB();
        public Form4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 13;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var name = textBox1.Text;
                var card = textBox2.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();
                string str = $"insert into purchase(login, card) values('{name}', '{card}')";
                SqlCommand sqlCommand = new SqlCommand(str, data.getConnection());
                data.OpenConnection();
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Succesfully!", "Thanks for purchase!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Invalid Operation!", "Try it again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                data.ClosedConnection();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
