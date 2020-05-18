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

namespace BookInfo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

       


        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1VN0V73;Initial Catalog=RegistrationDataBase;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Registration WHERE Username='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'", con);
            DataTable d = new DataTable();
            sda.Fill(d);
            
                if (d.Rows.Count == 1)
                {

                    this.Hide();
                    new BookInOut().Show();


                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Invalid Username or Password!");
                   
                }
                con.Close();
            
        }
        public string conString = "Data Source=DESKTOP-1VN0V73;Initial Catalog=RegistrationDataBase;Integrated Security=True";

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                if (textBox3.Text == "" || textBox4.Text == "") { MessageBox.Show("Warning! Enter values correctly!"); }
                else
                {

                    string q = "INSERT INTO Registration(Username,Password) VALUES('" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')";
                    SqlCommand c = new SqlCommand(q, con);
                    c.ExecuteNonQuery();

                    con.Close();
                    textBox3.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("Registration Successful!");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLoginForm().Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new NARPLibrary().Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

     
    }
}
