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
    public partial class IssueDetails : Form
    {
        public IssueDetails()
        {
            InitializeComponent();
        }

        private void IssueDetails_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1VN0V73;Initial Catalog=MemberDatabase;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Issue";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new NARPLibrary().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MemberInfo().Show();
        }

        private void IssueDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BookInfo().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MemberInfo().Show();
        }
    }
}
