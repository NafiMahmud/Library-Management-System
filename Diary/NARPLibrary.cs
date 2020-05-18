using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookInfo
{
    public partial class NARPLibrary : Form
    {
        public NARPLibrary()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLoginForm().Show();
        }

        private void NARPLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
