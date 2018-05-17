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

namespace userRegistrationform
{
    public partial class Form1 : Form
    {
        string ConnectionString = @"Data Source=AMEERABBASI;Initial Catalog=LOGINRF;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                if (textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("Please fill mandatory fields...");
                else if (textBox6.Text != textBox7.Text)
                    MessageBox.Show("Password do not match...");
                else
                {
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("UserAd", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@LastName", textBox2.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Contact", textBox3.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Address", textBox4.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Username", textBox5.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Password", textBox6.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Registrtion is successfully done...");
                    Clear();
                }
            }
        }
        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text =textBox7.Text= "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
