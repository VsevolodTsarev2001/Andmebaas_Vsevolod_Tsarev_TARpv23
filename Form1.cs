using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andmebaas_Vsevolod_Tsarev_TARpv23
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Andmebaas;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            
        }

        public void NaitaAndmed()
        {
            conn.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Toode",conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        

        public void button1_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty && Kogus_txt.Text.Trim() != string.Empty && Hind_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("INSERT INTO Toode(Nimetus,Kogus,Hind) VALUES (@toode,@kogus,@hind)", conn);
                    cmd.Parameters.AddWithValue("@toode", Nimetus_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    NaitaAndmed();
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }
    }
}
