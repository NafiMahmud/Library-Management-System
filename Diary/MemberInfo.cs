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
    public partial class MemberInfo : Form
    {
        public MemberInfo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string conString = "Data Source=DESKTOP-1VN0V73;Initial Catalog=LibraryManagement;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
                string q = "INSERT INTO MemberInfo(MemberName,MemberId,BookUsed,JoiningDate) VALUES('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + vDate + "')";
                SqlCommand c = new SqlCommand(q, con);
                c.ExecuteNonQuery();

                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                MessageBox.Show("Member Added Successfully");
                display();
            }
        }


        void display()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MemberInfo", con);
            DataTable d = new DataTable();
            sda.Fill(d);
            dataGridView1.Rows.Clear();
            foreach (DataRow r in d.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["membername"].Value = r["MemberName"].ToString();
                dataGridView1.Rows[n].Cells["memberid"].Value = r["MemberId"].ToString();
                dataGridView1.Rows[n].Cells["no"].Value = r["BookUsed"].ToString();
                dataGridView1.Rows[n].Cells["time"].Value = r["JoiningDate"].ToString();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
                string q = "UPDATE MemberInfo SET MemberName='" + textBox1.Text.ToString() + "', MemberId='" + textBox2.Text.ToString() + "', BookUsed='" + comboBox1.Text.ToString() + "', JoiningDate='" + vDate + "' WHERE (JoiningDate='" + vDate + "')";

                SqlCommand c = new SqlCommand(q, con);

                c.ExecuteNonQuery();


                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                MessageBox.Show("Member Modified Successfully");
                display();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {

                string q = "DELETE FROM MemberInfo WHERE(MemberName='" + textBox1.Text.ToString() + "')";

                SqlCommand c = new SqlCommand(q, con);

                c.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Member Removed Successfully");
                display();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BookInfo().Show();
        }

        private void MemberInfo_Load(object sender, EventArgs e)
        {
            display();
        }

        private void MemberInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string vDate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["membername"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["memberid"].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["no"].Value.ToString();
            vDate = dataGridView1.SelectedRows[0].Cells["time"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BookInfo().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new IssueDetails().Show();
        }
    }
}
