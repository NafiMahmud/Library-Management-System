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
    public partial class BookInOut : Form
    {
        public BookInOut()
        {
            InitializeComponent();
        }

        private void BookInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        
        private void BookInOut_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BookSearch().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new LoginForm().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public string conString = "Data Source=DESKTOP-1VN0V73;Initial Catalog=MemberDataBase;Integrated Security=True";

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
                string q = "INSERT INTO Issue(MemberName,MemberId,IssuedBook,BookId,Date) VALUES('" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + vDate + "')";
                SqlCommand c = new SqlCommand(q, con);
                c.ExecuteNonQuery();

                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                
                MessageBox.Show("Book Issued Successfully");
                display();
            }
        }
        void display()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Issue", con);
            DataTable d = new DataTable();
            sda.Fill(d);
            dataGridView1.Rows.Clear();
            foreach (DataRow r in d.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["bname"].Value = r["IssuedBook"].ToString();
                dataGridView1.Rows[n].Cells["bid"].Value = r["BookId"].ToString();
                dataGridView1.Rows[n].Cells["date"].Value = r["Date"].ToString();

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["bname"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["bid"].Value.ToString();
            vDate = dataGridView1.SelectedRows[0].Cells["date"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {

                string q = "DELETE FROM Issue WHERE(IssuedBook='" + textBox1.Text.ToString() + "')";

                SqlCommand c = new SqlCommand(q, con);

                c.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Book Submitted Successfully");
                display();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}
