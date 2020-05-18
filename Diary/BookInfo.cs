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
    public partial class BookInfo : Form
    {


        public BookInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["bookname"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["bookid"].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["grp"].Value.ToString();
            vDate = dataGridView1.SelectedRows[0].Cells["time"].Value.ToString();
        }

        public string conString = "Data Source=DESKTOP-1VN0V73;Initial Catalog=LibraryManagement;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
                string q = "INSERT INTO BookInfo(BookName,BookId,BookSelection,StoringDate) VALUES('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + vDate + "')";
                SqlCommand c = new SqlCommand(q, con);
                c.ExecuteNonQuery();

                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                MessageBox.Show("Book Added Successfully");
                display();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {

                string q = "DELETE FROM BookInfo WHERE(BookName='" + textBox1.Text.ToString() + "')";

                SqlCommand c = new SqlCommand(q, con);

                c.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Book Removed Successfully");
                display();
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Diary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
                string q = "UPDATE BookInfo SET BookName='" + textBox1.Text.ToString() + "', BookId='" + textBox2.Text.ToString() + "', BookSelection='" + comboBox1.Text.ToString() + "', StoringDate='" + vDate + "' WHERE (StoringDate='" + vDate + "')";

                SqlCommand c = new SqlCommand(q, con);

                c.ExecuteNonQuery();


                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                MessageBox.Show("Book Modified Successfully");
                display();
                
            }


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["bookname"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["bookid"].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["grp"].Value.ToString();
            vDate = dataGridView1.SelectedRows[0].Cells["time"].Value.ToString();
        }

     

        void display() 
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM BookInfo",con);
            DataTable d = new DataTable();
            sda.Fill(d);
            dataGridView1.Rows.Clear();
            foreach(DataRow r in d.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["bookname"].Value = r["BookName"].ToString();
                dataGridView1.Rows[n].Cells["bookid"].Value = r["BookId"].ToString();
                dataGridView1.Rows[n].Cells["grp"].Value = r["BookSelection"].ToString();
                dataGridView1.Rows[n].Cells["time"].Value = r["StoringDate"].ToString();
                
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex=-1;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MemberInfo().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLoginForm().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new IssueDetails().Show();
        }
    }
}