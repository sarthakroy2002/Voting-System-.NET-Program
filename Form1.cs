using System;
using System.Data.SqlClient;

namespace VotingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int bjp = 0;
        public static int inc = 0;
        public static int nota = 0;
        public static int voted = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (voted == 0)
            {
                bjp++;
                voted++;
                label6.Text = "Selected: BJP";
            }
        }

        private void button3_Click(object sender, EventArgs e02)
        {
            if (voted == 0)
            {
                inc++;
                voted++;
                label6.Text = "Selected: INC";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (voted == 0)
            {
                nota++;
                voted++;
                label6.Text = "Selected: NOTA";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            try
            {
                if (id != "" && id.Length==10)
                {
                    string query = "";
                    SqlConnection conn = new SqlConnection("data source=.;database=Election;integrated security=SSPI");
                    SqlCommand cmd;

                    if (bjp == 1)
                    {
                        query = "INSERT INTO vote VALUES('" + id + "', 'BJP')";
                        bjp = 0;
                    }
                    else if (inc == 1)
                    {
                        query = "INSERT INTO vote VALUES('" + id + "', 'INC')";
                        inc = 0;
                    }
                    else if (nota == 1)
                    {
                        query = "INSERT INTO vote VALUES('" + id + "', 'NOTA')";
                        nota = 0;
                    }

                    if (query != "")
                    {
                        conn.Open();
                        cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    label6.Text = "Selected:";
                    textBox1.Text = "";
                    voted = 0;
                    MessageBox.Show("Voted!");
                }
                else
                {
                    MessageBox.Show("ID cannot be empty or less than 10 characters.");
                    label6.Text = "Selected:";
                    textBox1.Text = "";
                    voted = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
