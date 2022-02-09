using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABDB2
{
    public partial class Form2 : Form
    {
        DB data = new DB();
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 10;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var login_user = textBox1.Text;
                var password_user = textBox2.Text;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();
                string querystring = $"select id_user, login, password from register where login = '{login_user}' and password = '{password_user}'";
                SqlCommand sqlCommand = new SqlCommand(querystring, data.getConnection());
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count == 1)
                {
                    MessageBox.Show("Succesfully!", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form1 form1 = new Form1();
                    Form2 form2 = new Form2();
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.ShowDialog();
                    form3.Show();

                }
                else
                {
                    MessageBox.Show("Error!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
    }

