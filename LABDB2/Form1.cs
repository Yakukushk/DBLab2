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
    public partial class Form1 : Form
    {
        DB data = new DB();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var login_user = textBox1.Text;
                var password_user = textBox2.Text;
                string str = $"insert into register(login, password) values('{login_user}', '{password_user}')";
                SqlCommand sqlCommand = new SqlCommand(str, data.getConnection());

                data.OpenConnection();
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Succesfully!", "Welcome!");
                    Form1 form1 = new Form1();
                    Form2 form2 = new Form2();
                    form1.Hide();
                    form2.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("User not add!", "Check information!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                data.ClosedConnection();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
        public Boolean Check() {
           
                var login = textBox1.Text;
                var password = textBox2.Text;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string str = $"select id_user, login, password from register where login = '{login}' and password = '{password}'";
                SqlCommand command = new SqlCommand(str, data.getConnection());
                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("This User has account", "Try it change!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                else
                {
                    return false;
                }
            
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
