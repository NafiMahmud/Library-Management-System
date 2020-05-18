using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookInfo
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1VN0V73;Initial Catalog=AdminLoginDataBase;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM AdminLogin WHERE Username='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'", con);
            DataTable d = new DataTable();
            sda.Fill(d);
            
                if (d.Rows.Count == 1)
                {

                    this.Hide();
                    new BookInfo().Show();


                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Invalid Username or Password!");
                   
                }
                con.Close();
            
        }
        public string conString = "Data Source=DESKTOP-1VN0V73;Initial Catalog=AdminLoginDataBase;Integrated Security=True";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new NARPLibrary().Show();
        }
        }
    }
