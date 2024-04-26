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

namespace VotingSystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string pass = textBox2.Text;

            if (id == "admin@election.com" && pass == "election")
            {
                SqlConnection conn = new SqlConnection("data source=.;database=Election;integrated security=SSPI");
                conn.Open();

                string queryBJP = "SELECT COUNT(*) FROM vote WHERE party = 'BJP'";
                string queryINC = "SELECT COUNT(*) FROM vote WHERE party = 'INC'";
                string queryNOTA = "SELECT COUNT(*) FROM vote WHERE party = 'NOTA'";

                SqlCommand cmdBJP = new SqlCommand(queryBJP, conn);
                SqlCommand cmdINC = new SqlCommand(queryINC, conn);
                SqlCommand cmdNOTA = new SqlCommand(queryNOTA, conn);

                int bjp = (int)cmdBJP.ExecuteScalar();
                int inc = (int)cmdINC.ExecuteScalar();
                int nota = (int)cmdNOTA.ExecuteScalar();

                label9.Text = bjp.ToString();
                label8.Text = inc.ToString();
                label7.Text = nota.ToString();

                conn.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
